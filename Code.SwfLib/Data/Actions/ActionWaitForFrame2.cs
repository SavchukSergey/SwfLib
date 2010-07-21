namespace Code.SwfLib.Data.Actions {
    public class ActionWaitForFrame2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.WaitForFrame2; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
