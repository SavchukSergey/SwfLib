using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionOr : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Or; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
