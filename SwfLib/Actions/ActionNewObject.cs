namespace SwfLib.Actions {
    public class ActionNewObject : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.NewObject; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
