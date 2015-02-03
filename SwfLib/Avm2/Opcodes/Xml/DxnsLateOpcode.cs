namespace SwfLib.Avm2.Opcodes.Xml {
    /// <summary>
    /// Sets the default XML namespace with a value determined at runtime. 
    /// </summary>
    public class DxnsLateOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return "dxnslate";
        }
    }
}
