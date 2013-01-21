using System.Collections.Generic;
using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionPush : ActionBase {

        public readonly IList<ActionPushItem> Items = new List<ActionPushItem>();

        public override ActionCode ActionCode {
            get { return ActionCode.Push; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
