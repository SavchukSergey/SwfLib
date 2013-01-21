namespace Code.SwfLib.Data.Actions {
    public class ActionMBStringExtract : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.MBStringExtract; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
