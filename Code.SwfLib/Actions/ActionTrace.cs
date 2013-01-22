namespace Code.SwfLib.Actions {
    public class ActionTrace : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Trace; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
