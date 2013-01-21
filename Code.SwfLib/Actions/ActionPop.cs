using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionPop : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Pop; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
