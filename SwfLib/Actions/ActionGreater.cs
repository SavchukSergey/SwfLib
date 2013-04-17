namespace SwfLib.Actions {
    /// <summary>
    /// Represents Greater action.
    /// </summary>
    public class ActionGreater : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.Greater; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
