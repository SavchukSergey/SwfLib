using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionEnumerate2 : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.Enumerate2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
