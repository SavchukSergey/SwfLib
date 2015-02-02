using System.Runtime.InteropServices;

namespace SwfLib.Avm2.Opcodes.Debug {
    /// <summary>
    /// Debugging info.
    /// </summary>
    public class DebugOpcode : BaseAvm2Opcode {

        public byte DebugType { get; set; }

        public string Name { get; set; }
        
        public byte Register { get; set; }
        
        public uint Extra { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
