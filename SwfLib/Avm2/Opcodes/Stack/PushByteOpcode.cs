namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Push a byte value. 
    /// </summary>
    public class PushByteOpcode : BaseAvm2Opcode {

        public byte Value { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
