using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionAsciiToChar : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.AsciiToChar; }
        }
        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
