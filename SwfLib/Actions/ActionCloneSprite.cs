namespace Code.SwfLib.Actions {
    public class ActionCloneSprite : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.CloneSprite; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
