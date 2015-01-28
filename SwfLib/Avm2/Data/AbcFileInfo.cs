﻿namespace SwfLib.Avm2.Data {
    public class AbcFileInfo {

        public ushort MinorVersion;
        
        public ushort MajorVersion;

        public AsConstantPoolInfo ConstantPool;

        public AsMethodInfo[] Methods;
        
        public AsMetadataInfo[] Metadata;
        
        public AsInstanceInfo[] Instances;
        
        public AsClassInfo[] Classes;
        
        public AsScriptInfo[] Scripts;
        
        public AsMethodBodyInfo[] Bodies;

    }
}
