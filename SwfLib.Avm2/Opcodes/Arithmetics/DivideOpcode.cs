namespace SwfLib.Avm2.Opcodes.Arithmetics {
    /// <summary>
    /// Divide two values. 
    /// </summary>
    public class DivideOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
