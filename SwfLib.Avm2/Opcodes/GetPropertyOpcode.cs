namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Get a property. 
    /// </summary>
    public class GetPropertyOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
