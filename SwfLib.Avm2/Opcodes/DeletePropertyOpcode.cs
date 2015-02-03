namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Delete a property. 
    /// </summary>
    public class DeletePropertyOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
