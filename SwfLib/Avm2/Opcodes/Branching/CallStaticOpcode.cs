namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Call a method identified by index in the abcFile method table. 
    /// </summary>
    public class CallStaticOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
