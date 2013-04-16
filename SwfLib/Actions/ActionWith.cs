using System.Collections.Generic;

namespace Code.SwfLib.Actions {
    public class ActionWith : ActionBase {
        
        public readonly IList<ActionBase> Actions = new List<ActionBase>();

        public override ActionCode ActionCode {
            get { return ActionCode.With; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
