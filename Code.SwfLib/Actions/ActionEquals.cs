using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionEquals : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Equals; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
