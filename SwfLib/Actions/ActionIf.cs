using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionIf : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.If;}
        }

        public short BranchOffset;

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
