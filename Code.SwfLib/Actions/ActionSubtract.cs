using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionSubtract : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Subtract; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
