namespace SwfLib.Actions {
    /// <summary>
    /// Represents RandomNumber action.
    /// </summary>
    public class ActionRandomNumber : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.RandomNumber; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
