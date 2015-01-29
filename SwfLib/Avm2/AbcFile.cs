using System;
using System.Collections.Generic;
using System.Linq;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFile {

        private readonly IList<AbcMethod> _methods = new List<AbcMethod>();
        private readonly IList<AbcClass> _classes = new List<AbcClass>();

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
                    Body = body != null ? GetMethodBody(body) : null
                };
                res.Methods.Add(method);
            }

            for (var i = 0; i < info.Classes.Length; i++) {
                var cInfo = info.Classes[i];
                var iInfo = info.Instances[i];
                var cls = new AbcClass {
                    Instance = new AbcInstance {
                        Name = GetMultiname(iInfo.Name, info),
                        SuperName = iInfo.SuperName > 0 ? GetMultiname(iInfo.SuperName, info) : null
                    }
                };
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

        private static AbcMethodBody GetMethodBody(AsMethodBodyInfo info) {
            return new AbcMethodBody {
                MaxStack = info.MaxStack,
                LocalCount = info.LocalCount,
                InitScopeDepth = info.InitScopeDepth,
                MaxScopeDepth = info.MaxScopeDepth,
                //todo: other fields
            };
        }

        private static AbcMultiname GetMultiname(uint index, AbcFileInfo abc) {
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
    }

    public class AbcClass {

        public AbcInstance Instance { get; set; }

        public AbcMethod ClassInitializer { get; set; }

        //public AsTraitsInfo[] Traits;

    }

    public class AbcInstance {

        //todo: must be QName
        public AbcMultiname Name { get; set; }

        public AbcMultiname SuperName { get; set; }

        //public byte Flags; // todo: InstanceFlags bitmask

        //public uint ProtectedNs;

        //public uint[] Interfaces;

        public AbcMethod InstanceInitializer;

        //public AsTraitsInfo[] Traits;

        //public bool HasProtectedNs {
        //    get { return (Flags & (int)AsInstanceFlags.ProtectedNs) != 0; }
        //}
    }

    public class AbcMethod {

        public string Name { get; set; }

        public AbcMethodBody Body { get; set; }

        /*
    public uint[] ParamTypes;

        public uint ReturnType;

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

    public class AbcMethodParam {

    }

    public class AbcMethodBody {
        public uint MaxStack { get; set; }

        public uint LocalCount { get; set; }

        public uint InitScopeDepth;

        public uint MaxScopeDepth;

        //todo:
        //public AsExceptionInfo[] Exceptions;

        //public AsTraitsInfo[] Traits;

        //public byte[] Code;

    }

    public abstract class AbcMultiname {

    }

    public class AbcMultinameQName : AbcMultiname {

        public string Name { get; set; }

        public AbcNamespace Namespace { get; set; }

        public override string ToString() {
            return string.Format("{0}:{1}", Namespace, Name);
        }
    }

    public class AbcNamespace {
        public AsType Kind;

        public string Name { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}", Kind, !string.IsNullOrWhiteSpace(Name) ? Name : "*");
        }
    }
}
