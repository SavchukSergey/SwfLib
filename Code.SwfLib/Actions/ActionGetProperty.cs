using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGetProperty : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GetProperty; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
