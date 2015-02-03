namespace SwfLib.Avm2 {
    public class AbcExceptionBlock {

        public uint From { get; set; }

        public uint To { get; set; }

        public uint Target { get; set; }

        public AbcMultiname ExceptionType { get; set; }

        public AbcMultiname VariableName { get; set; }

    }
}
