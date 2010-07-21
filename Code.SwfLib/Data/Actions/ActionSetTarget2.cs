namespace Code.SwfLib.Data.Actions {
    public class ActionSetTarget2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetTarget2; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
