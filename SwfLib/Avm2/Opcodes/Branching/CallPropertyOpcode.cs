namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Call a property.
    /// </summary>
    public class CallPropertyOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
