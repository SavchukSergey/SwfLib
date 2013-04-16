namespace Code.SwfLib.Actions {
    public class ActionJump : ActionBase {

        public short BranchOffset;

        public override ActionCode ActionCode {
            get { return ActionCode.Jump; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
