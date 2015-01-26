namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Search the scope stack for a property. 
    /// </summary>
    public class FindPropertyOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
