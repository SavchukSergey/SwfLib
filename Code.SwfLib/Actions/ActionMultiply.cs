using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionMultiply : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Multiply; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
