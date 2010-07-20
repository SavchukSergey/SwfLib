namespace Code.SwfLib.Data.Actions {
    public class ActionPlay : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Play; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
