using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionDelete : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.Delete; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
