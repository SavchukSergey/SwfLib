namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Find a property. 
    /// </summary>
    public class FindPropStrictOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
