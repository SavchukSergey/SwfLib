namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Gets a property from a base class. 
    /// </summary>
    public class GetSuperOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
