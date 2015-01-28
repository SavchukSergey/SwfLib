namespace SwfLib.Avm2.Data {
    public struct AsInstanceInfo {

        public uint Name;

        public uint SuperName;

        public byte Flags; // todo: InstanceFlags bitmask

        public uint ProtectedNs;

        public uint[] Interfaces;

        public uint InstanceInitializer;

        public AsTraitsInfo[] Traits;

        public bool HasProtectedNs {
            get { return (Flags & (int) AsInstanceFlags.ProtectedNs) != 0; }
        }
    }
}
