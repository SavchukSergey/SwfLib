namespace SwfLib.Actions {
    public class ActionToNumber : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.ToNumber; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
