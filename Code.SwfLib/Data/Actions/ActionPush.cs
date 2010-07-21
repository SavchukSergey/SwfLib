namespace Code.SwfLib.Data.Actions {
    public class ActionPush : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Push; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
