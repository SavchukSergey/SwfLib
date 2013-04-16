namespace Code.SwfLib.Actions {
    public class ActionOr : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Or; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
