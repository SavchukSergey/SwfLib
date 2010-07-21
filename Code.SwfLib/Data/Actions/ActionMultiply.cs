namespace Code.SwfLib.Data.Actions {
    public class ActionMultiply : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Multiply; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
