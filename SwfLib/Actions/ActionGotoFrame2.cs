namespace SwfLib.Actions {
    /// <summary>
    /// Represents GoToFrame2 action.
    /// </summary>
    public class ActionGotoFrame2 : ActionBase {

        public bool Play { get; set; }

        public byte Reserved { get; set; }

        /// <summary>
        /// Gets or sets scene bias.
        /// </summary>
        public ushort? SceneBias { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame2; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
