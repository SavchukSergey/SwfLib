namespace Code.SwfLib.Data.Actions {
    public class ActionSubtract : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Substract; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
