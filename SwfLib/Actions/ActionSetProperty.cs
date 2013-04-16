using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionSetProperty : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetProperty; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
