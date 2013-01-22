namespace Code.SwfLib.Actions {
    public class ActionConstantPool : ActionBase {

        public string[] ConstantPool;

        public override ActionCode ActionCode {
            get { return ActionCode.ConstantPool; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
