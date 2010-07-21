namespace Code.SwfLib.Data.Actions {
    public class ActionGetURL2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GetURL2; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
