namespace SwfLib.Avm2.Opcodes {
    public class SetLocalOpcode : BaseAvm2Opcode {

        public uint Register { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
