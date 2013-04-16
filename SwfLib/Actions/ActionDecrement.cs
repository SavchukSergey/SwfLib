using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public class ActionDecrement : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Decrement; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
