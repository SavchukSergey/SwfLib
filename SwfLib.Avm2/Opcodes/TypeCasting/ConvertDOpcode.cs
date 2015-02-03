namespace SwfLib.Avm2.Opcodes.TypeCasting {
    /// <summary>
    /// Convert a value to a double. 
    /// </summary>
    public class ConvertDOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
