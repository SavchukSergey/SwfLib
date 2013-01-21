namespace Code.SwfLib.Data.Actions {
    public class ActionGoToLabel : ActionBase {

        public string Label;

        public override ActionCode ActionCode {
            get { return ActionCode.GoToLabel; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
