namespace SwfLib.Avm2.Data {
    public struct AsMethodBodyInfo {
        
        public uint Method;
        
        public uint MaxStack;
        
        public uint LocalCount;
        
        public uint InitScopeDepth;
        
        public uint MaxScopeDepth;
        
        public AsExceptionInfo[] Exceptions;
        
        public AsTraitsInfo[] Traits;

        public byte[] Code;

    }
}
