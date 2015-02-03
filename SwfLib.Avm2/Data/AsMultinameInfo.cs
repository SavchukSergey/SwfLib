namespace SwfLib.Avm2.Data {
    public struct AsMultinameInfo {

        public AsMultinameKind Kind;

        public AsMultinameQName QName;

        public AsMultinameRTQName RtqName;

        public AsMultinameRTQNameL RtqNameL;

        public AsMultinameMultiname Multiname;

        public AsMultinameMultinameL MultinameL;

        public AsMultinameTypeName TypeName;

    }

    public struct AsMultinameQName {

        public uint Namespace;

        public uint Name;

    }

    public struct AsMultinameRTQName {

        public uint Name;

    }

    public struct AsMultinameRTQNameL {
    }

    public struct AsMultinameMultiname {

        public uint Name;

        public uint NamespaceSet;

    }

    public struct AsMultinameMultinameL {

        public uint NamespaceSet;

    }

    /// <summary>
    /// Vector
    /// </summary>
    public struct AsMultinameTypeName {
        
        public uint Name;

        public uint[] Params;

    }
}
