namespace Code.SwfLib.Data.Actions {
    public class ActionJump : ActionBase {

        public short BranchOffset;

        public override ActionCode ActionCode {
            get { return ActionCode.Jump; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
