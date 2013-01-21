using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionSetProperty : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.SetProperty; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
