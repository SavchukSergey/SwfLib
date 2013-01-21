using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionPreviousFrame : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.PreviousFrame; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
