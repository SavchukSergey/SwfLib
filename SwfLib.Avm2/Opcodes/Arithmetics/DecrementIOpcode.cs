namespace SwfLib.Avm2.Opcodes.Arithmetics {
    /// <summary>
    /// Decrement an integer value. 
    /// </summary>
    public class DecrementIOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
