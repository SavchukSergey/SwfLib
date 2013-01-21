using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionGotoFrame2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame2; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
