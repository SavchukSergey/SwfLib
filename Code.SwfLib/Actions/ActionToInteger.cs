using Code.SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionToInteger : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.ToInteger; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
