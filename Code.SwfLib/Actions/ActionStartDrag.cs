using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionStartDrag : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StartDrag; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
