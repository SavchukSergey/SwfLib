namespace SwfLib.Actions {
    public class ActionSetVariable : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.SetVariable; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
