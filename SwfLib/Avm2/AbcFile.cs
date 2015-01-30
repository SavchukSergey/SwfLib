using System;
using System.Collections.Generic;
using System.Linq;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFile {

        private readonly IList<AbcMethod> _methods = new List<AbcMethod>();
        private readonly IList<AbcClass> _classes = new List<AbcClass>();
        private readonly IList<AbcScript> _scripts = new List<AbcScript>();

        public ushort MajorVersion;

        public ushort MinorVersion;

        //public AsMetadataInfo[] Metadata;

        //public AsScriptInfo[] Scripts;

        public IList<AbcMethod> Methods {
            get { return _methods; }
        }

        public IList<AbcClass> Classes {
            get { return _classes; }
        }

        public IList<AbcScript> Scripts {
            get { return _scripts; }
        }

        public static AbcFile From(AbcFileInfo info) {
            var res = new AbcFile {
                MajorVersion = info.MajorVersion,
                MinorVersion = info.MinorVersion
            };

            var bodies = info.Bodies.ToDictionary(item => item.Method);
            for (var i = 0; i < info.Methods.Length; i++) {
                var methodInfo = info.Methods[i];
                AsMethodBodyInfo body;
                bodies.TryGetValue((uint)i, out body);
                var method = new AbcMethod {
                    Name = info.ConstantPool.Strings[methodInfo.Name],
                    Body = body != null ? GetMethodBody(body) : null,
                    ReturnType = GetMultiname(methodInfo.ReturnType, info)
                };
                for (int index = 0; index < methodInfo.ParamTypes.Length; index++) {
                    var paramInfo = methodInfo.ParamTypes[index];
                    var param = new AbcMethodParam {
                        Type = paramInfo != 0 ? GetMultiname(paramInfo, info) : AbcMultiname.Any,
                        Name = methodInfo.HasParamNames ? info.ConstantPool.Strings[methodInfo.ParamNames[index].ParamName] : null,
                        Default = methodInfo.HasOptional ? GetParamDefaultValue(methodInfo.Options[index], info) : null,
                    };
                    method.Params.Add(param);
                }
                res.Methods.Add(method);
            }

            for (var i = 0; i < info.Scripts.Length; i++) {
                var scriptInfo = info.Scripts[i];
                var script = new AbcScript();
                AddTraits(script.Traits, scriptInfo.Traits);
                res.Scripts.Add(script);
            }

            for (var i = 0; i < info.Classes.Length; i++) {
                var cInfo = info.Classes[i];
                var iInfo = info.Instances[i];
                var cls = new AbcClass {
                    Instance = new AbcInstance {
                        Name = GetMultiname(iInfo.Name, info),
                        SuperName = iInfo.SuperName > 0 ? GetMultiname(iInfo.SuperName, info) : null,
                    }
                };
                AddTraits(cls.Traits, cInfo.Traits);
                foreach (var index in iInfo.Interfaces) {
                    cls.Instance.Interfaces.Add(GetMultiname(index, info));
                }
                res.Classes.Add(cls);
            }

            for (var i = 0; i < res.Classes.Count; i++) {
                var cls = res.Classes[i];
                var clsInfo = info.Classes[i];
                var iInfo = info.Instances[i];
                cls.ClassInitializer = res.Methods[(int)clsInfo.ClassInitializer];
                cls.Instance.InstanceInitializer = res.Methods[(int)iInfo.InstanceInitializer];
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
                default:
                    throw new Exception("unknown default value");
            }
        }

        private static AbcMethodBody GetMethodBody(AsMethodBodyInfo info) {
            var res = new AbcMethodBody {
                MaxStack = info.MaxStack,
                LocalCount = info.LocalCount,
                InitScopeDepth = info.InitScopeDepth,
                MaxScopeDepth = info.MaxScopeDepth,
                //todo: other fields
            };
            AddTraits(res.Traits, info.Traits);
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

        private static void AddTraits(ICollection<AbcTrait> target, IEnumerable<AsTraitsInfo> infos) {
            foreach (var info in infos) {
                target.Add(GetTrait(info));
            }
        }

        private static AbcTrait GetTrait(AsTraitsInfo trait) {
            return new AbcTrait();
        }

    }


    public class AbcMethod {

        private readonly IList<AbcMethodParam> _params = new List<AbcMethodParam>();

        public string Name { get; set; }

        public AbcMethodBody Body { get; set; }

        public IList<AbcMethodParam> Params {
            get { return _params; }
        }

        public AbcMultiname ReturnType { get; set; }

        /*
        public byte Flags; // todo: MethodFlags bitmask

        public AsOptionDetailInfo[] Options;

        public AsParamInfo[] ParamNames;

        public bool HasOptional {
            get { return (Flags & (int)AsMethodFlags.HasOptional) != 0; }
        }

        public bool HasParamNames {
            get { return (Flags & (int)AsMethodFlags.HasParamNames) != 0; }
        }
         */
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
