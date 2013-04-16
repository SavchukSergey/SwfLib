using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionDefineLocal2 : ActionBase {
       
        public override ActionCode ActionCode {
            get { return ActionCode.DefineLocal2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
