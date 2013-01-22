namespace Code.SwfLib.Actions {
    public class ActionNot : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Not; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
