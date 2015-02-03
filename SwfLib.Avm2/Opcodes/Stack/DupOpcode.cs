namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Duplicates the top value on the stack. 
    /// </summary>
    public class DupOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
