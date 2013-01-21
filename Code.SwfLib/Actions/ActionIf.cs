using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionIf : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.If;}
        }

        public short BranchOffset;

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
