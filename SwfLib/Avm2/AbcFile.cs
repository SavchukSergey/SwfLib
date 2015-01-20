namespace SwfLib.Avm2 {
    public class AbcFile {

        public ushort MinorVersion;
        
        public ushort MajorVersion;

        public AsConstantPool ConstantPool;

        public AsMethodInfo[] Methods;
        
        public AsMetadata[] Metadata;
        
        public AsInstance[] Instances;
        
        public AsClass[] Classes;
        
        public AsScript[] Scripts;
        
        public AsMethodBody[] Bodies;

    }
}
