namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Search the scope stack for a property. 
    /// </summary>
    public class FindPropertyOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return string.Format("findproperty {0}", Name);
        }
    }
}
