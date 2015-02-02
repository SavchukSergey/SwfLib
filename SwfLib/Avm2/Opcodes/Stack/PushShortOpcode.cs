namespace SwfLib.Avm2.Opcodes.Stack {
    public class PushShortOpcode : BaseAvm2Opcode {

        public uint Value { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
