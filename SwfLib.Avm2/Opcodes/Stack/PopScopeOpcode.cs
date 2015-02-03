namespace SwfLib.Avm2.Opcodes.Stack {
    /// <summary>
    /// Pop a scope off of the scope stack 
    /// </summary>
    public class PopScopeOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
