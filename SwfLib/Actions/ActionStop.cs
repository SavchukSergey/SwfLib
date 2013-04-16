namespace Code.SwfLib.Actions {
    public class ActionStop : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.Stop; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
