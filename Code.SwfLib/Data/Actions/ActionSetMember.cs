namespace Code.SwfLib.Data.Actions {
    public class ActionSetMember : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetMember; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
