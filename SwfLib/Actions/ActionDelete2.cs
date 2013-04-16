using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public class ActionDelete2 : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.Delete2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
