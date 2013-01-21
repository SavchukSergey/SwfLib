using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionEquals : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Equals; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
