using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionStrictEquals : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.StrictEquals; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
