using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionDefineFunction : ActionBase {

        public string FunctionName;

        public string[] Params;

        public byte[] Body;

        public override ActionCode ActionCode {
            get { return ActionCode.DefineFunction; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
