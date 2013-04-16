namespace Code.SwfLib.Actions {
    public class ActionInitArray : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.InitArray; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
