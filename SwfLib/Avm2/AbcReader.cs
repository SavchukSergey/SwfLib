using System;

namespace SwfLib.Avm2 {

    public class AbcReader {
        private readonly SwfStreamReader _reader;

        public AbcReader(SwfStreamReader reader) {
            _reader = reader;
        }

        public AbcFile ReadAbcFile() {
            try {
                return new AbcFile {
                    MinorVersion = ReadU16(),
                    MajorVersion = ReadU16(),
                    ConstantPool = ReadConstantPool(),
                    Methods = ReadMultipleMethods(),
                    Metadata = ReadMutipleMetadata(),
                    Instances = ReadMutipleInstances(),
                    Classes = ReadMultipleClasses(),
                    Scripts = ReadMultipleScripts(),
                    Bodies = ReadMultipleBodies()
                };
            } catch (Exception e) {
                throw new Exception(string.Format("Error at {0} ({0:x}):", _reader.Position), e);
            }
        }

        private AsMetadata[] ReadMutipleMetadata() {
            var len = ReadU30();
            var res = new AsMetadata[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadMetadata();
            }
            return res;
        }

        private AsInstance[] ReadMutipleInstances() {
            var len = ReadU30();
            var res = new AsInstance[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadInstance();
            }
            return res;
        }

        private AsMethodInfo[] ReadMultipleMethods() {
            var len = ReadU30();
            var res = new AsMethodInfo[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadMethodInfo();
            }
            return res;
        }

        private AsClass[] ReadMultipleClasses() {
            var len = ReadU30();
            var res = new AsClass[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadClass();
            }
            return res;
        }

        private AsScript[] ReadMultipleScripts() {
            var len = ReadU30();
            var res = new AsScript[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadScript();
            }
            return res;
        }

        private AsMethodBody[] ReadMultipleBodies() {
            var len = ReadU30();
            var res = new AsMethodBody[len];
            for (var i = 0; i < len; i++) {
                res[i] = ReadMethodBody();
            }
            return res;
        }

        private AsConstantPool ReadConstantPool() {
            var res = new AsConstantPool();

            res.Integers = new int[ReadU30()];
            for (var i = 1; i < res.Integers.Length; i++) {
                res.Integers[i] = ReadS32();
            }

            res.UnsignedIntegers = new uint[ReadU30()];
            for (var i = 1; i < res.UnsignedIntegers.Length; i++) {
                res.UnsignedIntegers[i] = ReadU32();
            }

            res.Doubles = new double[ReadU30()];
            for (var i = 1; i < res.Doubles.Length; i++) {
                res.Doubles[i] = ReadD64();
            }

            res.Strings = new string[ReadU30()];
            for (var i = 1; i < res.Strings.Length; i++) {
                res.Strings[i] = ReadString();
            }

            res.Namespaces = new AsNamespace[ReadU30()];
            for (var i = 1; i < res.Namespaces.Length; i++) {
                res.Namespaces[i] = ReadNamespace();
            }

            res.NamespaceSets = new AsNamespaceSet[ReadU30()];
            for (var i = 1; i < res.NamespaceSets.Length; i++) {
                res.NamespaceSets[i] = ReadNamespaceSet();
            }

            res.Multinames = new AsMultiname[ReadU30()];
            for (var i = 1; i < res.Multinames.Length; i++) {
                res.Multinames[i] = ReadMultiname();
            }

            return res;
        }

        private AsNamespace ReadNamespace() {
            return new AsNamespace {
                Kind = (AsType)ReadU8(),
                Name = ReadU30()
            };
        }

        private AsNamespaceSet ReadNamespaceSet() {
            return new AsNamespaceSet {
                Namespaces = ReadMultipleU30()
            };
        }

        private AsMultiname ReadMultiname() {
            var r = new AsMultiname { Kind = (AsType)ReadU8() };
            switch (r.Kind) {
                case AsType.QName:
                case AsType.QNameA:
                    r.QName = new AsMultinameQName {
                        Namespace = ReadU30(),
                        Name = ReadU30()
                    };
                    break;
                case AsType.RTQName:
                case AsType.RTQNameA:
                    r.RtqName = new AsMultinameRTQName {
                        Name = ReadU30()
                    };
                    break;
                case AsType.RTQNameL:
                case AsType.RTQNameLA:
                    break;
                case AsType.Multiname:
                case AsType.MultinameA:
                    r.Multiname = new AsMultinameMultiname {
                        Name = ReadU30(),
                        NamespaceSet = ReadU30()
                    };
                    break;
                case AsType.MultinameL:
                case AsType.MultinameLA:
                    r.MultinameL = new AsMultinameMultinameL {
                        NamespaceSet = ReadU30()
                    };
                    break;
                case AsType.TypeName:
                    r.TypeName = new AsMultinameTypeName {
                        name = ReadU30(),
                        Params = ReadMultipleU30()
                    };
                    break;
                default:
                    throw new Exception("Unknown Multiname kind " + r.Kind);
            }
            return r;
        }

        private AsMethodInfo ReadMethodInfo() {
            var paramCount = ReadU30();
            var r = new AsMethodInfo {
                ParamTypes = new uint[paramCount],
                ReturnType = ReadU30()
            };
            r.ParamTypes = ReadMultipleU30(paramCount);
            r.Name = ReadU30();
            r.Flags = ReadU8();
            if (r.HasOptional) {
                r.Options = new AsOptionDetail[ReadU30()];
                for (var i = 0; i < r.Options.Length; i++) {
                    r.Options[i] = ReadOptionDetail();
                }
            }
            if (r.HasParamNames) {
                r.ParamNames = ReadMultipleParamInfo(paramCount);
            }
            return r;
        }

        private AsOptionDetail ReadOptionDetail() {
            return new AsOptionDetail {
                Value = ReadU30(),
                Kind = (AsType)ReadU8()
            };
        }

        private AsParamInfo[] ReadMultipleParamInfo(uint cnt) {
            var res = new AsParamInfo[cnt];
            for (var i = 0; i < cnt; i++) {
                res[i] = ReadParamInfo();
            }
            return res;
        }

        private AsParamInfo ReadParamInfo() {
            return new AsParamInfo {
                ParamName = ReadU30()
            };
        }

        private AsMetadata ReadMetadata() {
            AsMetadata r;
            r.Name = ReadU30();
            r.Items = new AsMetadataItem[ReadU30()];
            //todo: first keys then values?
            for (var i = 0; i < r.Items.Length; i++) {
                r.Items[i] = ReadMetadataItem();
            }
            return r;
        }

        private AsMetadataItem ReadMetadataItem() {
            return new AsMetadataItem {
                Key = ReadU30(),
                Value = ReadU30()
            };
        }

        private AsInstance ReadInstance() {
            var r = new AsInstance {
                Name = ReadU30(),
                SuperName = ReadU30(),
                Flags = ReadU8()
            };
            if (r.HasProtectedNs)
                r.ProtectedNs = ReadU30();
            r.Interfaces = ReadMultipleU30();
            r.InstanceInitializer = ReadU30();
            r.Traits = ReadMutlipleTraits();

            return r;
        }

        private AsTraitsInfo[] ReadMutlipleTraits() {
            var res = new AsTraitsInfo[ReadU30()];
            for (var i = 0; i < res.Length; i++) {
                res[i] = ReadTrait();
            }
            return res;
        }

        private AsTraitsInfo ReadTrait() {
            var r = new AsTraitsInfo {
                Name = ReadU30(),
                Flags = ReadU8()
            };
            switch (r.Kind) {
                case AsTraitKind.Slot:
                case AsTraitKind.Const:
                    r.Slot.SlotId = ReadU30();
                    r.Slot.TypeName = ReadU30();
                    r.Slot.ValueIndex = ReadU30();
                    if (r.Slot.ValueIndex != 0)
                        r.Slot.ValueKind = (AsType)ReadU8();
                    else
                        r.Slot.ValueKind = AsType.Void;
                    break;
                case AsTraitKind.Class:
                    r.Class.SlotId = ReadU30();
                    r.Class.Class = ReadU30();
                    break;
                case AsTraitKind.Function:
                    r.Function.SlotId = ReadU30();
                    r.Function.Function = ReadU30();
                    break;
                case AsTraitKind.Method:
                case AsTraitKind.Getter:
                case AsTraitKind.Setter:
                    r.Method.DispId = ReadU30();
                    r.Method.Method = ReadU30();
                    break;
                default:
                    throw new Exception("Unknown trait kind");
            }
            if (r.HasMetadata) {
                r.Metadata = ReadMultipleU30();
            }
            return r;
        }

        private AsClass ReadClass() {
            return new AsClass {
                ClassInitializer = ReadU30(),
                Traits = ReadMutlipleTraits()
            };
        }

        private AsScript ReadScript() {
            return new AsScript {
                ScriptInitializer = ReadU30(),
                Traits = ReadMutlipleTraits()
            };
        }

        private AsMethodBody ReadMethodBody() {
            var r = new AsMethodBody {
                Method = ReadU30(),
                MaxStack = ReadU30(),
                LocalCount = ReadU30(),
                InitScopeDepth = ReadU30(),
                MaxScopeDepth = ReadU30(),
            };

            var len = ReadU30();
            r.Code = _reader.ReadBytes((int)len);

            r.Exceptions = ReadMultipleExceptions();
            r.Traits = ReadMutlipleTraits();

            return r;
        }

        private AsExceptionInfo[] ReadMultipleExceptions() {
            var res = new AsExceptionInfo[ReadU30()];
            for (var i = 0; i < res.Length; i++) {
                res[i] = ReadExceptionInfo();
            }
            return res;
        }

        private AsExceptionInfo ReadExceptionInfo() {
            return new AsExceptionInfo {
                From = ReadU30(),
                To = ReadU30(),
                Target = ReadU30(),
                ExceptionType = ReadU30(),
                VariableName = ReadU30()
            };
        }

        #region Primitives

        private byte ReadU8() {
            return _reader.ReadByte();
        }

        private ushort ReadU16() {
            return _reader.ReadUInt16();
        }

        private uint ReadU30() {
            return _reader.ReadEncodedU30();
        }

        private uint ReadU32() {
            return _reader.ReadEncodedU32();
        }

        private int ReadS32() {
            return _reader.ReadEncodedS32();
        }

        private uint[] ReadMultipleU30() {
            var len = ReadU30();
            return ReadMultipleU30(len);
        }

        private uint[] ReadMultipleU30(uint cnt) {
            var res = new uint[cnt];
            for (var i = 0; i < res.Length; i++) {
                res[i] = ReadU30();
            }
            return res;
        }

        private double ReadD64() {
            return _reader.ReadDouble();
        }

        private string ReadString() {
            var len = ReadU30();
            if (len == 0) return "";
            return _reader.ReadRawString((int)len);
        }

        #endregion

    }

}
