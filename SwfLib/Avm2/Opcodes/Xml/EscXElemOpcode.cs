namespace SwfLib.Avm2.Opcodes.Xml {
    /// <summary>
    /// Escape an xml element. 
    /// </summary>
    public class EscXElemOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
