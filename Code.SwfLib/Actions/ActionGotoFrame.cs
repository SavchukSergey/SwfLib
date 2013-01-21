using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGotoFrame : ActionBase {

        public ushort Frame;

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
