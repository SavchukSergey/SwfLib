namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Construct an instance of the base class. 
    /// </summary>
    public class ConstructSuperOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
