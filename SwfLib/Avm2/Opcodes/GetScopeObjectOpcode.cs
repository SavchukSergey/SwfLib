namespace SwfLib.Avm2.Opcodes {
    public class GetScopeObjectOpcode : BaseAvm2Opcode {

        public byte Index { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
