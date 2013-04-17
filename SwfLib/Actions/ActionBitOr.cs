namespace SwfLib.Actions {
    /// <summary>
    /// Represents BitOr action.
    /// </summary>
    public class ActionBitOr : ActionBase {
        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.BitOr; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
