namespace Code.SwfLib.Actions {
    public class ActionCallFunction : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.CallFunction; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
