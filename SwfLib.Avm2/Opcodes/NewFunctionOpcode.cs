namespace SwfLib.Avm2.Opcodes {
    public class NewFunctionOpcode : BaseAvm2Opcode {

        public AbcMethod Method { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
