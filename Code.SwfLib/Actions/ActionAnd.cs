using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionAnd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.And; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
