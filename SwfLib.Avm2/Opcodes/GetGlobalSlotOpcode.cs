namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Get the value of a slot on the global scope. 
    /// </summary>
    public class GetGlobalSlotOpcode : BaseAvm2Opcode {

        public uint SlotIndex { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
