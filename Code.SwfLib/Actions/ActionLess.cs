namespace Code.SwfLib.Data.Actions {
    public class ActionLess : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Less;  }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
