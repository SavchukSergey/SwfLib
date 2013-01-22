namespace Code.SwfLib.Actions {
    public class ActionEndDrag : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.EndDrag; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
