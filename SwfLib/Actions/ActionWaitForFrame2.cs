using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionWaitForFrame2 : ActionBase {

        public byte SkipCount;

        public override ActionCode ActionCode {
            get { return ActionCode.WaitForFrame2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
