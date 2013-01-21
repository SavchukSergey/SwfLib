using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionEndDrag : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.EndDrag; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
