namespace Code.SwfLib.Data.Actions {
    public class ActionStopSounds : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.StopSounds; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
