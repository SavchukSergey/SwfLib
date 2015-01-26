namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Pop the top value from the stack. 
    /// </summary>
    public class PopOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
