using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionSetTarget2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetTarget2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
