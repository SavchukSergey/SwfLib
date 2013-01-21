using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionMBStringLength : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.MBStringLength; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
