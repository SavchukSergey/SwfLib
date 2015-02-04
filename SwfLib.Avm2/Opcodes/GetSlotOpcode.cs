namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Get the value of a slot. 
    /// </summary>
    public class GetSlotOpcode : BaseAvm2Opcode {

        public uint SlotIndex { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
