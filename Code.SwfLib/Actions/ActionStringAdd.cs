namespace Code.SwfLib.Actions {
    public class ActionStringAdd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringAdd; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
