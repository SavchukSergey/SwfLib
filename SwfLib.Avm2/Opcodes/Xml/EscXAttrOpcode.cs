namespace SwfLib.Avm2.Opcodes.Xml {
    /// <summary>
    /// Escape an xml attribute. 
    /// </summary>
    public class EscXAttrOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
