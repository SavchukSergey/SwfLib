using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionStoreRegister : ActionBase {
        
        public byte RegisterNumber;

        public override ActionCode ActionCode {
            get { return ActionCode.StoreRegister; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
