namespace Code.SwfLib.Data.Actions {
    public class ActionRemoveSprite : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.RemoveSprite; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
