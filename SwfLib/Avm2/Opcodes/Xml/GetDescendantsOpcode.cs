namespace SwfLib.Avm2.Opcodes.Xml {
    /// <summary>
    /// Get descendants. 
    /// </summary>
    public class GetDescendantsOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
