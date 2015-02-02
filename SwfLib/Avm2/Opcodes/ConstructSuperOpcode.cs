namespace SwfLib.Avm2.Opcodes {
    /// <summary>
    /// Construct an instance of the base class. 
    /// </summary>
    public class ConstructSuperOpcode : BaseAvm2Opcode {

        /// <summary>
        /// arg_count is a u30 that is the number of arguments present on the stack. This will invoke the
        /// constructor on the base class of object with the given arguments.
        /// </summary>
        public uint ArgCount { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
