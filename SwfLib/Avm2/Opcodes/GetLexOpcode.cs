namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Find and get a property. 
    /// </summary>
    public class GetLexOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
