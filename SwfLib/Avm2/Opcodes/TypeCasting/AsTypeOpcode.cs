namespace SwfLib.Avm2.Opcodes.TypeCasting {
    /// <summary>
    /// Return the same value, or null if not of the specified type. 
    /// </summary>
    public class AsTypeOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
