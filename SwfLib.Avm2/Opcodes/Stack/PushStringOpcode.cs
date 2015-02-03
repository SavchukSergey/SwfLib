using Microsoft.SqlServer.Server;

namespace SwfLib.Avm2.Opcodes.Stack {
    public class PushStringOpcode : BaseAvm2Opcode {

        public string Value { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return string.Format("pushstring {0}", FormatString(Value));
        }

        private string FormatString(string val) {
            return '"' + val
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t")
                   + '"';
        }
    }
}
