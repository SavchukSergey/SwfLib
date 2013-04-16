namespace SwfLib.Actions {
    public class ActionStringLength : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringLength; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
