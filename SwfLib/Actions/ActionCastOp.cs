namespace SwfLib.Actions {
    public class ActionCastOp : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.CastOp; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
