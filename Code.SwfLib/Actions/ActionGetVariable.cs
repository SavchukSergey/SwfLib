namespace Code.SwfLib.Data.Actions {
    public class ActionGetVariable : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GetVariable; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
