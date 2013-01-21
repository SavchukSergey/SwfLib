namespace Code.SwfLib.Data.Actions {
    public class ActionNextFrame : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.NextFrame; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
