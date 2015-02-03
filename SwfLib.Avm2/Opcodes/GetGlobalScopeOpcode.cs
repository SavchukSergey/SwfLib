namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Gets the global scope. 
    /// </summary>
    public class GetGlobalScopeOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
