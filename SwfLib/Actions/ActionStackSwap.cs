namespace SwfLib.Actions {
    public class ActionStackSwap : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.StackSwap; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
