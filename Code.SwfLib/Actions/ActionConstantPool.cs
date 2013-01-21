namespace Code.SwfLib.Data.Actions {
    public class ActionConstantPool : ActionBase {


        public string[] ConstantPool;

        public override ActionCode ActionCode {
            get { return ActionCode.ConstantPool; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
