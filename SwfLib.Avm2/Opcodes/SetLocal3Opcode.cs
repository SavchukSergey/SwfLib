namespace SwfLib.Avm2.Opcodes {
    public class SetLocal3Opcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return "setlocal_3";
        }

    }
}
