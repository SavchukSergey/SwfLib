namespace Code.SwfLib.Actions {
    public class ActionTry : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.Try; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
