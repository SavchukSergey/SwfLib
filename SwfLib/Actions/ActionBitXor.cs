namespace SwfLib.Actions {
    public class ActionBitXor : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.BitXor; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
