namespace Code.SwfLib.Data.Actions {
    public class ActionCloneSprite : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.CloneSprite; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
