using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionAdd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Add; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
