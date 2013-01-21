using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionRandomNumber : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.RandomNumber; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
