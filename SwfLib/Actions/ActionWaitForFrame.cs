namespace SwfLib.Actions {
    /// <summary>
    /// Represents WaitForFrame action.
    /// </summary>
    public class ActionWaitForFrame : ActionBase {

        public ushort Frame;

        /// <summary>
        /// Gets or sets count of frames to be skipped.
        /// </summary>
        public byte SkipCount { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.WaitForFrame; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
