using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionDivide : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Divide; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
