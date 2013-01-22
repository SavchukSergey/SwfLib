using Code.SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGoToLabel : ActionBase {

        public string Label;

        public override ActionCode ActionCode {
            get { return ActionCode.GoToLabel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
