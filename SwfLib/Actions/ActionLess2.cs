namespace SwfLib.Actions {
    public class ActionLess2 : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.Less2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
