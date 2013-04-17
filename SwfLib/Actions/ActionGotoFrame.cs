namespace SwfLib.Actions {
    /// <summary>
    /// Represents GoToFrame action.
    /// </summary>
    public class ActionGotoFrame : ActionBase {

        public ushort Frame { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
