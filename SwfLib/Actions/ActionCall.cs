namespace SwfLib.Actions {
    public class ActionCall : ActionBase {
        
        //TODO: where are values for this multibyte action??

        public override ActionCode ActionCode {
            get { return ActionCode.Call; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
