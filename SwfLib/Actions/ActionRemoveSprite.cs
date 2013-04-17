namespace SwfLib.Actions {
    /// <summary>
    /// Represents RemoveSprite action.
    /// </summary>
    public class ActionRemoveSprite : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.RemoveSprite; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
