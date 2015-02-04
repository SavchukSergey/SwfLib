namespace SwfLib.Avm2.Opcodes {
    public class SetSlotOpcode : BaseAvm2Opcode {

        public uint SlotIndex { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
