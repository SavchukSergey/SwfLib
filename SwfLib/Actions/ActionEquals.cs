using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionEquals : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Equals; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
