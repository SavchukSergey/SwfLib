namespace SwfLib.Avm2.Opcodes {
    public class UnknownOpcode : BaseAvm2Opcode {
        private readonly Avm2Opcode _code;

        public UnknownOpcode(Avm2Opcode code) {
            _code = code;
        }

        public override Avm2Opcode Code {
            get { return _code; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
