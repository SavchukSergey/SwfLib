using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionStringAdd : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringAdd; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
