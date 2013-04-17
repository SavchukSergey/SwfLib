namespace SwfLib.Actions {
    /// <summary>
    /// Represents BitAnd action.
    /// </summary>
    public class ActionBitAnd : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.BitAnd; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
