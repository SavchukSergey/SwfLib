namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Check to make sure an object can have a filter operation performed on it. 
    /// </summary>
    public class CheckFilterOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
