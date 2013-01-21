namespace Code.SwfLib.Data.Actions {
    public class ActionCharToAscii : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.CharToAscii; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
