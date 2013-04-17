namespace SwfLib.Actions {
    /// <summary>
    /// Represents NewObject action.
    /// </summary>
    public class ActionNewObject : ActionBase {
        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.NewObject; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
