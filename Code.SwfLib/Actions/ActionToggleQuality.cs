namespace Code.SwfLib.Data.Actions {
    public class ActionToggleQuality : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.ToggleQuality; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
