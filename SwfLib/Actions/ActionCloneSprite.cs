namespace SwfLib.Actions {
    /// <summary>
    /// Represents CloneSprite action.
    /// </summary>
    public class ActionCloneSprite : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.CloneSprite; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
