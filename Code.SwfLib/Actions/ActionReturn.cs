using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionReturn : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Return; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
