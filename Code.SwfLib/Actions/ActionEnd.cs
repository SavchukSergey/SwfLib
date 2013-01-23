namespace Code.SwfLib.Actions {
    public class ActionEnd : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.End; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
