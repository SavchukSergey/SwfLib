namespace Code.SwfLib.Data.Actions {
    public class ActionGotoFrame : ActionBase {

        public ushort Frame;

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
