using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionCall : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Call; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
