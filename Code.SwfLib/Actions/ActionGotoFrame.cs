using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGotoFrame : ActionBase {

        public ushort Frame;

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
