using System.Collections.Generic;

namespace Code.SwfLib.Actions {
    public class ActionDefineFunction : ActionBase {

        public string Name;

        public readonly IList<string> Args = new List<string>();

        public readonly List<ActionBase> Actions = new List<ActionBase>();


        public override ActionCode ActionCode {
            get { return ActionCode.DefineFunction; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
