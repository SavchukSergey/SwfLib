using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionPreviousFrame : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.PreviousFrame; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
