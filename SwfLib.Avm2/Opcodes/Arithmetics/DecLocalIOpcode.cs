namespace SwfLib.Avm2.Opcodes.Arithmetics {
    /// <summary>
    /// Decrement a local register value. 
    /// </summary>
    public class DecLocalIOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
