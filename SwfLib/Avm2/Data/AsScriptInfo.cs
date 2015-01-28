namespace SwfLib.Avm2.Data {
    public struct AsScriptInfo {

        /// <summary>
        /// The init field is an index into the method array of the abcFile. It identifies a function that is to be 
        /// invoked prior to any other code in this script.
        /// </summary>
        public uint ScriptInitializer;

        public AsTraitsInfo[] Traits;

    }
}
