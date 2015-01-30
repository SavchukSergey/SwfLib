using System;
using System.Collections.Generic;
using System.Linq;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFile {

        private readonly IList<AbcMethod> _methods = new List<AbcMethod>();
        private readonly IList<AbcClass> _classes = new List<AbcClass>();
        private readonly IList<AbcScript> _scripts = new List<AbcScript>();
        private readonly IList<AbcMetadata> _metadata = new List<AbcMetadata>();

        public ushort MajorVersion;

        public ushort MinorVersion;

        public IList<AbcMethod> Methods {
            get { return _methods; }
        }

        public IList<AbcClass> Classes {
            get { return _classes; }
        }

        public IList<AbcScript> Scripts {
            get { return _scripts; }
        }

        public IList<AbcMetadata> Metadata {
            get { return _metadata; }
        }

        public static AbcFile From(AbcFileInfo fileInfo) {
            var res = new AbcFile {
                MajorVersion = fileInfo.MajorVersion,
                MinorVersion = fileInfo.MinorVersion
            };

            foreach (var metaInfo in fileInfo.Metadata) {
                res.Metadata.Add(GetMetadata(metaInfo, fileInfo));

            }
            var methods = GetMethods(fileInfo);
            foreach (var method in methods) {
                res.Methods.Add(method);
            }

            for (var i = 0; i < fileInfo.Scripts.Length; i++) {
                var scriptInfo = fileInfo.Scripts[i];
                var script = new AbcScript();
                AddTraits(fileInfo, script.Traits, scriptInfo.Traits);
                res.Scripts.Add(script);
            }

            for (var i = 0; i < fileInfo.Classes.Length; i++) {
                var cInfo = fileInfo.Classes[i];
                var iInfo = fileInfo.Instances[i];
                var cls = new AbcClass {
                    Instance = new AbcInstance {
                        Name = GetMultiname(iInfo.Name, fileInfo),
                        SuperName = iInfo.SuperName > 0 ? GetMultiname(iInfo.SuperName, fileInfo) : null,
                    }
                };
                AddTraits(fileInfo, cls.Traits, cInfo.Traits);
                foreach (var index in iInfo.Interfaces) {
                    cls.Instance.Interfaces.Add(GetMultiname(index, fileInfo));
                }
                res.Classes.Add(cls);
            }

            for (var i = 0; i < res.Classes.Count; i++) {
                var cls = res.Classes[i];
                var clsInfo = fileInfo.Classes[i];
                var iInfo = fileInfo.Instances[i];
                cls.ClassInitializer = res.Methods[(int)clsInfo.ClassInitializer];
                cls.Instance.InstanceInitializer = res.Methods[(int)iInfo.InstanceInitializer];
            }
            return res;
        }

        private static AbcMetadata GetMetadata(AsMetadataInfo metaInfo, AbcFileInfo info) {
            var res = new AbcMetadata {
                Name = info.ConstantPool.Strings[metaInfo.Name]
            };
            foreach (var item in metaInfo.Items) {
                res.Items.Add(new AbcMetadataItem {
                    Key = info.ConstantPool.Strings[item.Key],
                    Value = info.ConstantPool.Strings[item.Value]
                });
            }
            return res;
        }

        private static IEnumerable<AbcMethod> GetMethods(AbcFileInfo fileInfo) {
            var res = new List<AbcMethod>();
            var bodies = fileInfo.Bodies.ToDictionary(item => item.Method);
            for (var i = 0; i < fileInfo.Methods.Length; i++) {
                var methodInfo = fileInfo.Methods[i];
                AsMethodBodyInfo body;
                bodies.TryGetValue((uint)i, out body);
                var method = new AbcMethod {
                    Name = fileInfo.ConstantPool.Strings[methodInfo.Name],
                    Body = body != null ? GetMethodBody(fileInfo, body) : null,
                    ReturnType = GetMultiname(methodInfo.ReturnType, fileInfo),
                    NeedArguments = methodInfo.NeedArguments,
                    NeedActivation = methodInfo.NeedActivation,
                    NeedRest = methodInfo.NeedRest,
                    SetDxns = methodInfo.SetDxns,
                    IgnoreRest = methodInfo.IgnoreRest,
                    Native = methodInfo.Native,
                };
                for (int index = 0; index < methodInfo.ParamTypes.Length; index++) {
                    var paramInfo = methodInfo.ParamTypes[index];
                    var param = new AbcMethodParam {
                        Type = paramInfo != 0 ? GetMultiname(paramInfo, fileInfo) : AbcMultiname.Any,
                        Name = methodInfo.HasParamNames ? fileInfo.ConstantPool.Strings[methodInfo.ParamNames[index].ParamName] : null,
                        Default = methodInfo.HasOptional ? GetParamDefaultValue(methodInfo.Options[index], fileInfo) : null,
                    };
                    method.Params.Add(param);
                }
                res.Add(method);
            }
            return res;
        }

        private static AbcMethodParamDefaultValue GetParamDefaultValue(AsOptionDetailInfo info, AbcFileInfo fileInfo) {
            switch (info.Kind) {
                case AsConstantType.Integer:
                    return fileInfo.ConstantPool.Integers[info.Value];
                case AsConstantType.UInteger:
                    return fileInfo.ConstantPool.UnsignedIntegers[info.Value];
                case AsConstantType.Double:
                    return fileInfo.ConstantPool.Doubles[info.Value];
                case AsConstantType.String:
                    return fileInfo.ConstantPool.Strings[info.Value];
                case AsConstantType.True:
                    return true;
                case AsConstantType.False:
                    return false;
                case AsConstantType.Null:
                    return AbcMethodParamDefaultValue.Null;
                case AsConstantType.Undefined:
                    return AbcMethodParamDefaultValue.Undefined;
                case AsConstantType.Namespace:
                    return new AbcMethodParamNamespace { Value = GetNamespace(info.Value, fileInfo) };
                //todo: other types
                default:
                    throw new Exception("unknown default value");
            }
        }

        private static AbcMethodBody GetMethodBody(AbcFileInfo fileInfo, AsMethodBodyInfo info) {
            var res = new AbcMethodBody {
                MaxStack = info.MaxStack,
                LocalCount = info.LocalCount,
                InitScopeDepth = info.InitScopeDepth,
                MaxScopeDepth = info.MaxScopeDepth,
                //todo: other fields
            };
            AddTraits(fileInfo, res.Traits, info.Traits);
            return res;
        }

        private static AbcMultiname GetMultiname(uint index, AbcFileInfo abc) {
            if (index == 0) return new AbcMultinameVoid();
            var info = abc.ConstantPool.Multinames[index];
            switch (info.Kind) {
                case AsType.QName:
                    return new AbcMultinameQName {
                        Name = abc.ConstantPool.Strings[info.QName.Name],
                        Namespace = GetNamespace(info.QName.Namespace, abc)
                    };
                default:
                    throw new Exception("Unsupported nultiname kind");
            }
        }

        private static AbcNamespace GetNamespace(uint index, AbcFileInfo info) {
            var inner = info.ConstantPool.Namespaces[index];
            return new AbcNamespace {
                Kind = inner.Kind,
                Name = info.ConstantPool.Strings[inner.Name]
            };
        }

        private static void AddTraits(AbcFileInfo fileInfo, ICollection<AbcTrait> target, IEnumerable<AsTraitsInfo> infos) {
            foreach (var info in infos) {
                target.Add(GetTrait(fileInfo, info));
            }
        }

        private static AbcTrait GetTrait(AbcFileInfo fileInfo, AsTraitsInfo trait) {
            return new AbcTrait {
                Name = GetMultiname(trait.Name, fileInfo)
            };
        }

    }




    public abstract class AbcMultiname {

        public static readonly AbcMultinameAny Any = new AbcMultinameAny();

    }

    public class AbcMultinameQName : AbcMultiname {

        public string Name { get; set; }

        public AbcNamespace Namespace { get; set; }

        public override string ToString() {
            return string.Format("{0}:{1}", Namespace, Name);
        }
    }

    public class AbcMultinameVoid : AbcMultiname {

    }

    public class AbcMultinameAny : AbcMultiname {

    }

    public class AbcNamespace {
        public AsType Kind;

        public string Name { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}", Kind, !string.IsNullOrWhiteSpace(Name) ? Name : "*");
        }
    }
}
