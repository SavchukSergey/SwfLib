namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Call a property, discarding the return value. 
    /// </summary>
    public class CallPropVoidOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
