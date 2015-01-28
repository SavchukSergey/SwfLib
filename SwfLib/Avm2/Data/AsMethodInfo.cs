namespace SwfLib.Avm2.Data {
    public struct AsMethodInfo {
        
        public uint[] ParamTypes;

        public uint ReturnType;

        public uint Name;
        
        public byte Flags; // todo: MethodFlags bitmask

        public AsOptionDetailInfo[] Options;

        public AsParamInfo[] ParamNames;

        public bool HasOptional {
            get { return (Flags & (int)AsMethodFlags.HasOptional) != 0; }
        }

        public bool HasParamNames {
            get { return (Flags & (int)AsMethodFlags.HasParamNames) != 0; }
        }
    }
}
