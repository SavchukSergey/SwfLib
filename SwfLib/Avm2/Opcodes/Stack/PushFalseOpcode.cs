namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Push false. 
    /// </summary>
    public class PushFalseOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
