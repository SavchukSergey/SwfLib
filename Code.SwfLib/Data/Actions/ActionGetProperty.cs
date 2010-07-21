namespace Code.SwfLib.Data.Actions {
    public class ActionGetProperty : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GetProperty; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
