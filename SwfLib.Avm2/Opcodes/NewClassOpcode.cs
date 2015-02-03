namespace SwfLib.Avm2.Opcodes {
    public class NewClassOpcode : BaseAvm2Opcode {

        public AbcClass BaseType { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
