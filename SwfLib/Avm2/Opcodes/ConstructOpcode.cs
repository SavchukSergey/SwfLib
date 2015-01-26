namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Construct an instance. 
    /// </summary>
    public class ConstructOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
