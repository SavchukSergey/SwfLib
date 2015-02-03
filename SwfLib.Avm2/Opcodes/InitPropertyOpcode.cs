namespace SwfLib.Avm2.Opcodes {
    public class InitPropertyOpcode : BaseAvm2Opcode {

        public AbcMultiname Name { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return string.Format("initproperty {0}", Name);
        }

    }
}
