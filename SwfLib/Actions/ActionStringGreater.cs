namespace SwfLib.Actions {
    public class ActionStringGreater : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.StringGreater; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
