namespace SwfLib.Actions {
    /// <summary>
    /// Represents ImplementsOp action.
    /// </summary>
    public class ActionImplementsOp : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.ImplementsOp; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
