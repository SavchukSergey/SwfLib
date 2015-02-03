namespace SwfLib.Avm2.Opcodes.Branching {
    /// <summary>
    /// Determine if one value is greater than another. 
    /// </summary>
    public class GreaterThanOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
