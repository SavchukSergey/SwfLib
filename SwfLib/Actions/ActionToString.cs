namespace Code.SwfLib.Actions {
    public class ActionToString : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.ToString; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
