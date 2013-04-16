using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public class ActionBitOr : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.BitOr; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
