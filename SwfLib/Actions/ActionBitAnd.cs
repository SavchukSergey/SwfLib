using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public class ActionBitAnd : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.BitAnd; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
