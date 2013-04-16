namespace SwfLib.Actions {
    public class ActionPlay : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Play; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
