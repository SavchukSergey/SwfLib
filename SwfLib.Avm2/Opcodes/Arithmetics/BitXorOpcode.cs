namespace SwfLib.Avm2.Opcodes.Arithmetics {
    /// <summary>
    /// Bitwise exclusive or. 
    /// </summary>
    public class BitXorOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
