using System.Collections.Generic;

namespace SwfLib.Avm2.Opcodes.Branching {
    public class LookupSwitchOpcode : BaseAvm2Opcode {

        private readonly IList<int> _casesRelativeOffset = new List<int>();

        public int DefaultRelativeOffset { get; set; }

        public IList<int> CasesRelativeOffset {
            get { return _casesRelativeOffset; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
