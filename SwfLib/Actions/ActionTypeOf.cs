namespace SwfLib.Actions {
    public class ActionTypeOf : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.TypeOf; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
