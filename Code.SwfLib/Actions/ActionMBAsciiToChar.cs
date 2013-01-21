namespace Code.SwfLib.Data.Actions {
    public class ActionMBAsciiToChar : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.MBAsciiToChar; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
