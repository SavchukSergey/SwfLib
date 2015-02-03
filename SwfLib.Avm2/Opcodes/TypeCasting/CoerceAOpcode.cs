namespace SwfLib.Avm2.Opcodes.TypeCasting {
    /// <summary>
    /// Coerce a value to the any type. 
    /// </summary>
    public class CoerceAOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
