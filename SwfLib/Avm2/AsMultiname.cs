namespace SwfLib.Avm2 {
    public struct AsMultiname {

        public AsType Kind;

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

    //todo:???
    public struct AsMultinameTypeName {
        public uint name;
        public uint[] Params;
    }
}
