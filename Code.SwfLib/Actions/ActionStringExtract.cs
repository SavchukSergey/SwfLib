namespace Code.SwfLib.Data.Actions {
    public class ActionStringExtract : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.StringExtract; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
