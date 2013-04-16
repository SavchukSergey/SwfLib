namespace SwfLib.Actions {
    public class ActionPushDuplicate : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.PushDuplicate; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
