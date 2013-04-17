namespace SwfLib.Actions {
    /// <summary>
    /// Represents Delete action.
    /// </summary>
    public class ActionDelete : ActionBase {
        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.Delete; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
