namespace Code.SwfLib.Data.Actions {
    public class ActionToInteger : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.ToInteger; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
