namespace Code.SwfLib.Data.Actions {
    public class ActionStringEquals : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringEquals; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
