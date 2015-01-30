namespace SwfLib.Avm2.Data {
    public struct AsMethodInfo {

        public uint[] ParamTypes;

        public uint ReturnType;

        public uint Name;

        public AsMethodFlags Flags;

        public AsOptionDetailInfo[] Options;

        public AsParamInfo[] ParamNames;

        public bool HasOptional {
            get { return (Flags & AsMethodFlags.HasOptional) != 0; }
        }

        public bool HasParamNames {
            get { return (Flags & AsMethodFlags.HasParamNames) != 0; }
        }

        public bool NeedArguments {
            get { return (Flags & AsMethodFlags.NeedArguments) != 0; }
        }

        public bool NeedRest {
            get { return (Flags & AsMethodFlags.NeedRest) != 0; }
        }

        public bool NeedActivation {
            get { return (Flags & AsMethodFlags.NeedActivation) != 0; }
        }

        public bool SetDxns {
            get { return (Flags & AsMethodFlags.SetDxns) != 0; }
        }

        public bool IgnoreRest {
            get { return (Flags & AsMethodFlags.IgnoreRest) != 0; }
        }

        public bool Native {
            get { return (Flags & AsMethodFlags.Native) != 0; }
        }
    }
}
