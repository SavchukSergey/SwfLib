namespace SwfLib.Actions {
    public class ActionSetMember : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetMember; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
