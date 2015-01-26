namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Construct a property. 
    /// </summary>
    public class ConstructPropOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
