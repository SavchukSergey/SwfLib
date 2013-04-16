namespace Code.SwfLib.Actions {
    public class ActionEquals2 : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.Equals2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
