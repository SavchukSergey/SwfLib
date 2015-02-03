namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Push a double value onto the stack. 
    /// </summary>
    public class PushDoubleOpcode : BaseAvm2Opcode {

        public double Value { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
