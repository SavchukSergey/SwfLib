namespace Code.SwfLib.Data.Actions {
    public class ActionStringLength : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringLength; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
