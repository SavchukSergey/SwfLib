namespace SwfLib.Avm2.Opcodes.Arithmetics {
    public class IncLocalIOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public uint Register { get; set; }

        public override string ToString() {
            return "inclocal_i";
        }
    }
}
