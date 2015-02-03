namespace SwfLib.Avm2.Opcodes.TypeCasting {
    /// <summary>
    /// Convert a value to a string. 
    /// </summary>
    public class ConvertSOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
