using System.Collections.Generic;

namespace SwfLib.Actions {
    public class ActionConstantPool : ActionBase {

        public readonly IList<string> ConstantPool = new List<string>();

        public override ActionCode ActionCode {
            get { return ActionCode.ConstantPool; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
