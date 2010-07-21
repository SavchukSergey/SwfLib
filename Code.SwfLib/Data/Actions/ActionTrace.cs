namespace Code.SwfLib.Data.Actions {
    public class ActionTrace : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Trace; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
