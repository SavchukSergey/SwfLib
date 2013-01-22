using Code.SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionAnd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.And; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
