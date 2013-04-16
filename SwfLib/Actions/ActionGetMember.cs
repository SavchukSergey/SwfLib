namespace SwfLib.Actions {
    public class ActionGetMember : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.GetMember; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
