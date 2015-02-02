namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Construct a property. 
    /// </summary>
    public class ConstructPropOpcode : BaseAvm2Opcode {

        public uint ArgCount { get; set; }

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
