using System;
using System.Collections.Generic;
using System.Linq;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFileLoader {

        public AbcFileInfo FileInfo;

        public readonly IList<AbcClass> Classes = new List<AbcClass>();

        public readonly IList<AbcScript> Scripts = new List<AbcScript>();

        public readonly IList<AbcMethod> Methods = new List<AbcMethod>();

        public readonly IList<AbcMetadata> Metadata = new List<AbcMetadata>();

        public readonly IList<AbcNamespace> Namespaces = new List<AbcNamespace>();

        public readonly IList<AbcMultiname> Multinames = new List<AbcMultiname>();

        public AbcFileLoader(AbcFileInfo fileInfo) {
            FileInfo = fileInfo;

            ReadConstants();


            for (var i = 0; i < fileInfo.Classes.Length; i++) {
                Classes.Add(new AbcClass());
            }

            for (var i = 0; i < fileInfo.Scripts.Length; i++) {
                Scripts.Add(new AbcScript());
            }

            foreach (var methodInfo in fileInfo.Methods) {
                var method = new AbcMethod {
                    Name = fileInfo.ConstantPool.Strings[methodInfo.Name],
                    ReturnType = methodInfo.ReturnType != 0 ? GetMultiname(methodInfo.ReturnType) : AbcMultiname.Void,
                    NeedArguments = methodInfo.NeedArguments,
                    NeedActivation = methodInfo.NeedActivation,
                    NeedRest = methodInfo.NeedRest,
                    SetDxns = methodInfo.SetDxns,
                    IgnoreRest = methodInfo.IgnoreRest,
                    Native = methodInfo.Native,
                };
                for (var paramIndex = 0; paramIndex < methodInfo.ParamTypes.Length; paramIndex++) {
                    var paramInfo = methodInfo.ParamTypes[paramIndex];
                    var param = new AbcMethodParam {
                        Type = paramInfo != 0 ? GetMultiname(paramInfo) : AbcMultiname.Any,
                        Name = methodInfo.HasParamNames ? fileInfo.ConstantPool.Strings[methodInfo.ParamNames[paramIndex].ParamName] : null,
                        Default = methodInfo.HasOptional ? GetConstantValue(methodInfo.Options[paramIndex].Kind, methodInfo.Options[paramIndex].Value) : null,
                    };
                    method.Params.Add(param);
                }
                Methods.Add(method);
            }
            LoadClassInstances();
            LoadMethodBodies();
            LoadClassInitializers();
            LoadTraits();
        }

        private void LoadClassInstances() {
            for (var i = 0; i < FileInfo.Instances.Length; i++) {
                var instanceInfo = FileInfo.Instances[i];
                var @class = Classes[i];
                @class.Instance = new AbcInstance {
                    Name = GetMultiname(instanceInfo.Name),
                    SuperName = GetMultiname(instanceInfo.SuperName),
                };
                foreach (var index in instanceInfo.Interfaces) {
                    @class.Instance.Interfaces.Add(GetMultiname(index));
                }
            }
        }

        private void LoadTraits() {
            for (var i = 0; i < FileInfo.Scripts.Length; i++) {
                var scriptInfo = FileInfo.Scripts[i];
                var script = Scripts[i];
                AddTraits(script.Traits, scriptInfo.Traits);
            }
            foreach (var bodyInfo in FileInfo.Bodies) {
                var method = GetMethod(bodyInfo.Method);
                var methodBody = method.Body;
                AddTraits(methodBody.Traits, bodyInfo.Traits);
            }
            for (var i = 0; i < FileInfo.Instances.Length; i++) {
                var instanceInfo = FileInfo.Instances[i];
                var instance = Classes[i].Instance;
                AddTraits(instance.Traits, instanceInfo.Traits);
            }
            for (var i = 0; i < FileInfo.Classes.Length; i++) {
                var classInfo = FileInfo.Classes[i];
                var @class = Classes[i];
                AddTraits(@class.Traits, classInfo.Traits);
            }
        }

        private void ReadConstants() {
            foreach (var ns in FileInfo.ConstantPool.Namespaces) {
                Namespaces.Add(new AbcNamespace {
                    Kind = ns.Kind,
                    Name = FileInfo.ConstantPool.Strings[ns.Name]
                });
            }

            foreach (var multiname in FileInfo.ConstantPool.Multinames) {
                switch (multiname.Kind) {
                    case AsType.QName:
                        Multinames.Add(new AbcMultinameQName {
                            Name = FileInfo.ConstantPool.Strings[multiname.QName.Name],
                            Namespace = GetNamespace(multiname.QName.Namespace)
                        });
                        break;
                    case AsType.Void:
                        Multinames.Add(AbcMultiname.Void);
                        break;
                    case AsType.Multiname:
                    case AsType.MultinameL:
                        Multinames.Add(AbcMultiname.Void); //todo:
                        break;
                    default:
                        throw new Exception("Unsupported multiname kind " + multiname.Kind);
                }
            }
        }

        private void LoadClassInitializers() {
            for (var i = 0; i < Classes.Count; i++) {
                var cls = Classes[i];
                var clsInfo = FileInfo.Classes[i];
                var iInfo = FileInfo.Instances[i];
                cls.ClassInitializer = GetMethod(clsInfo.ClassInitializer);
                cls.Instance.InstanceInitializer = GetMethod(iInfo.InstanceInitializer);
            }
        }

        private void LoadMethodBodies() {
            var bodies = FileInfo.Bodies.ToDictionary(item => item.Method);
            for (var i = 0; i < Methods.Count; i++) {
                var method = Methods[i];
                AsMethodBodyInfo body;
                bodies.TryGetValue((uint)i, out body);
                method.Body = body != null ? GetMethodBody(body) : null;
            }
        }

        private AbcMethodBody GetMethodBody(AsMethodBodyInfo info) {
            var res = new AbcMethodBody {
                MaxStack = info.MaxStack,
                LocalCount = info.LocalCount,
                InitScopeDepth = info.InitScopeDepth,
                MaxScopeDepth = info.MaxScopeDepth,
                //todo: other fields
            };
            return res;
        }

        private void AddTraits(ICollection<AbcTrait> target, IEnumerable<AsTraitsInfo> infos) {
            foreach (var info in infos) {
                target.Add(GetTrait(info));
            }
        }

        private AbcTrait GetTrait(AsTraitsInfo traitInfo) {
            AbcTrait trait;
            switch (traitInfo.Kind) {
                case AsTraitKind.Const:
                    trait = new AbcConstTrait {
                        SlotId = traitInfo.Slot.SlotId,
                        TypeName = GetMultiname(traitInfo.Slot.TypeName),
                        Value = GetConstantValue(traitInfo.Slot.ValueKind, traitInfo.Slot.ValueIndex)
                    };
                    break;
                case AsTraitKind.Slot:
                    trait = new AbcSlotTrait {
                        SlotId = traitInfo.Slot.SlotId,
                        TypeName = traitInfo.Slot.TypeName != 0 ? GetMultiname(traitInfo.Slot.TypeName) : AbcMultiname.Any,
                        Value = GetConstantValue(traitInfo.Slot.ValueKind, traitInfo.Slot.ValueIndex)
                    };
                    break;
                case AsTraitKind.Class:
                    trait = new AbcClassTrait {
                        SlotId = traitInfo.Class.SlotId,
                        Class = GetClass(traitInfo.Class.Class)
                    };
                    break;
                case AsTraitKind.Method:
                    trait = new AbcMethodTrait {
                        DispId = traitInfo.Method.DispId,
                        Method = GetMethod(traitInfo.Method.Method)
                    };
                    break;
                case AsTraitKind.Getter:
                    trait = new AbcGetterTrait {
                        DispId = traitInfo.Method.DispId,
                        Method = GetMethod(traitInfo.Method.Method)
                    };
                    break;
                case AsTraitKind.Setter:
                    trait = new AbcSetterTrait {
                        DispId = traitInfo.Method.DispId,
                        Method = GetMethod(traitInfo.Method.Method)
                    };
                    break;
                default:
                    throw new Exception("unsupported trait kind " + traitInfo.Kind);
            }

            trait.Name = GetMultiname(traitInfo.Name);
            return trait;
        }

        private AbcConstant GetConstantValue(AsConstantType kind, uint value) {
            switch (kind) {
                case AsConstantType.Integer:
                    return FileInfo.ConstantPool.Integers[value];
                case AsConstantType.UInteger:
                    return FileInfo.ConstantPool.UnsignedIntegers[value];
                case AsConstantType.Double:
                    return FileInfo.ConstantPool.Doubles[value];
                case AsConstantType.String:
                    return FileInfo.ConstantPool.Strings[value];
                case AsConstantType.True:
                    return true;
                case AsConstantType.False:
                    return false;
                case AsConstantType.Null:
                    return AbcConstant.Null;
                case AsConstantType.Undefined:
                    return AbcConstant.Undefined;
                case AsConstantType.Namespace:
                    return value != 0 ? GetNamespace(value) : AbcNamespace.Any;
                //todo: other types
                default:
                    throw new Exception("unknown constant");
            }
        }

        public void SaveTo(AbcFile file) {
            foreach (var method in Methods) {
                file.Methods.Add(method);
            }
            foreach (var @class in Classes) {
                file.Classes.Add(@class);
            }
            foreach (var script in Scripts) {
                file.Scripts.Add(script);
            }
        }

        public AbcMultiname GetMultiname(uint index) {
            if (index == 0) throw new Exception("multiname index cannot be zero");
            return Multinames[(int)index];
        }

        public AbcNamespace GetNamespace(uint index) {
            if (index == 0) throw new Exception("ambigous zero multiname");
            return Namespaces[(int)index];
        }

        private AbcMethod GetMethod(uint index) {
            return Methods[(int)index];
        }

        public AbcClass GetClass(uint index) {
            return Classes[(int)index];
        }
    }
}
