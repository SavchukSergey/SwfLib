namespace Code.SwfLib.Actions {
    public class ActionBitURShift : ActionBase {
        
        public override ActionCode ActionCode {
            get { return ActionCode.BitURShift; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
