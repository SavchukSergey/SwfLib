namespace SwfLib.Avm2.Opcodes {
    public class HasNext2Opcode : BaseAvm2Opcode {

        public uint ObjectReg { get; set; }

        public uint IndexReg { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
