using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionWaitForFrame : ActionBase {

        public ushort Frame;

        public byte SkipCount;

        public override ActionCode ActionCode {
            get { return ActionCode.WaitForFrame; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
