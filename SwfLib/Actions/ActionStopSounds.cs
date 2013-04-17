namespace SwfLib.Actions {
    /// <summary>
    /// Represents StopSounds action.
    /// </summary>
    public class ActionStopSounds : ActionBase {
        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.StopSounds; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
