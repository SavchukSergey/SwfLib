namespace Code.SwfLib.Actions {
    public class ActionImplementsOp : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.ImplementsOp; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
