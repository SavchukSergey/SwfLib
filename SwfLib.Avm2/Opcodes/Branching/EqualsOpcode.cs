namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Compare two values. 
    /// </summary>
    public class EqualsOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return "equals";
        }
    }
}
