using System.Collections.Generic;

namespace Code.SwfLib.Data.Actions {
    public class ActionPush : ActionBase {

        public readonly IList<ActionPushItem> Items = new List<ActionPushItem>();

        public override ActionCode ActionCode {
            get { return ActionCode.Push; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
