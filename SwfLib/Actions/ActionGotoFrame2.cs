namespace SwfLib.Actions {
    /// <summary>
    /// Represents GoToFrame2 action.
    /// </summary>
    public class ActionGotoFrame2 : ActionBase {

        public bool Play { get; set; }

        public byte Reserved { get; set; }

        public ushort? SceneBias { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
