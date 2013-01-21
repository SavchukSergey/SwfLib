using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionStop : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.Stop; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
