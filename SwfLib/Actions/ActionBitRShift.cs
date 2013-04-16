namespace SwfLib.Actions {
    public class ActionBitRShift : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.BitRShift; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
