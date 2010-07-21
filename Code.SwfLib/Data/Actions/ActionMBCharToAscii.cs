namespace Code.SwfLib.Data.Actions {
    public class ActionMBCharToAscii : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.MBCharToAscii; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
