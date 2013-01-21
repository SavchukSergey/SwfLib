namespace Code.SwfLib.Data.Actions {
    public class ActionNot : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Not; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
