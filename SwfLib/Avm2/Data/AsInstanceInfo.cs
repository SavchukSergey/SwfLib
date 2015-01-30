namespace SwfLib.Avm2.Data {
    public struct AsInstanceInfo {

        public uint Name;

        public uint SuperName;

        public AsInstanceFlags Flags;

        public uint ProtectedNs;

        public uint[] Interfaces;

        public uint InstanceInitializer;

        public AsTraitsInfo[] Traits;

        public bool HasProtectedNs {
            get { return ((int)Flags & (int) AsInstanceFlags.ProtectedNs) != 0; }
        }
    }
}
