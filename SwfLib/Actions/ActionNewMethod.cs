namespace Code.SwfLib.Actions {
    public class ActionNewMethod : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.NewMethod; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
