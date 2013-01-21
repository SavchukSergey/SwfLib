namespace Code.SwfLib.Data.Actions {
    public class ActionAdd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Add; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
