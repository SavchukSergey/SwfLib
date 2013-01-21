using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionWaitForFrame : ActionBase {

        public ushort Frame;

        public byte SkipCount;

        public override ActionCode ActionCode {
            get { return ActionCode.WaitForFrame; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
