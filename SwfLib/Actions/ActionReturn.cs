namespace SwfLib.Actions {
    public class ActionReturn : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Return; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
