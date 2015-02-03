namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Call a property, discarding the return value. 
    /// </summary>
    public class CallPropVoidOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public uint ArgCount { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
