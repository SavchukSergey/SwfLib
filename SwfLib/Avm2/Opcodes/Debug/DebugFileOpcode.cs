﻿namespace SwfLib.Avm2.Opcodes.Debug {
    /// <summary>
    /// Debugging line number info. 
    /// </summary>
    public class DebugFileOpcode : BaseAvm2Opcode {

        public string FileName { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
