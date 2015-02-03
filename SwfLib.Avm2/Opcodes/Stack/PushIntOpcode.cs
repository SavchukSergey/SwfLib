namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Push an int value onto the stack. 
    /// </summary>
    public class PushIntOpcode : BaseAvm2Opcode {

        public int Value { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
