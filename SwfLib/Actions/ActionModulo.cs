namespace Code.SwfLib.Actions {
    public class ActionModulo : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.Modulo; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
