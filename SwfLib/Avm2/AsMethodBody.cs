namespace SwfLib.Avm2 {
    public struct AsMethodBody {
        
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
