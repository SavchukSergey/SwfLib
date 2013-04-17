namespace SwfLib.Actions {
    /// <summary>
    /// Represents StringAdd action.
    /// </summary>
    public class ActionStringAdd : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.StringAdd; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
