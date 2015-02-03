namespace SwfLib.Avm2.Opcodes.Debug {
    public class BreakpointOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return "bkpt";
        }
    }
}
