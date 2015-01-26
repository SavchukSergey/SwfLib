namespace SwfLib.Avm2.Opcodes.Debug {
    /// <summary>
    /// Debugging line number info. 
    /// </summary>
    public class DebugLineOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
