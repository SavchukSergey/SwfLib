namespace Code.SwfLib.Actions {
    public class ActionInitObject : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.InitObject; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
