namespace Code.SwfLib.Data.Actions {
    public class ActionStringLess : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringLess; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
