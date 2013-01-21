using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionGetTime : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GetTime; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
