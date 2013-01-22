namespace Code.SwfLib.Actions {
    public class ActionIncrement : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.Increment; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
