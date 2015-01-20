namespace SwfLib.Avm2 {
    public struct AsMethodInfo {
        
        public uint[] ParamTypes;

        public uint ReturnType;

        public uint Name;
        
        public byte Flags; // todo: MethodFlags bitmask

        public AsOptionDetail[] Options;

        public AsParamInfo[] ParamNames;

        public bool HasOptional {
            get { return (Flags & (int)AsMethodFlags.HAS_OPTIONAL) != 0; }
        }

        public bool HasParamNames {
            get { return (Flags & (int)AsMethodFlags.HAS_PARAM_NAMES) != 0; }
        }
    }
}
