namespace Code.SwfLib.Actions {
    public class ActionDefineLocal : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.DefineLocal; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
