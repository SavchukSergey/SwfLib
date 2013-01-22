namespace Code.SwfLib.Actions {
    public class ActionToggleQuality : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.ToggleQuality; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
