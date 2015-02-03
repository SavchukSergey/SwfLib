namespace SwfLib.Avm2.Opcodes.Xml {
    /// <summary>
    /// Sets the default XML namespace. 
    /// </summary>
    public class DxnsOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
