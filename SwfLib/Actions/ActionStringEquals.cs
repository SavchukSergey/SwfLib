namespace SwfLib.Actions {
    public class ActionStringEquals : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringEquals; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
