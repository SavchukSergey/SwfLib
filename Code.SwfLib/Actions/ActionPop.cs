namespace Code.SwfLib.Actions {
    public class ActionPop : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Pop; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
