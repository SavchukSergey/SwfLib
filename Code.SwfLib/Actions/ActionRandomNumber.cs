using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionRandomNumber : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.RandomNumber; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
