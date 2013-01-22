using Code.SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionSetTarget : ActionBase {

        public string TargetName;

        public override ActionCode ActionCode {
            get { return ActionCode.SetTarget; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
