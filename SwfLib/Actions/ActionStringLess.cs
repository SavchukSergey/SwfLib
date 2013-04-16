namespace SwfLib.Actions {
    public class ActionStringLess : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringLess; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
