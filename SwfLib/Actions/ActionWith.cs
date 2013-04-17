using System.Collections.Generic;

namespace SwfLib.Actions {
    public class ActionWith : ActionBase {
        
        /// <summary>
        /// Gets or sets list of actions.
        /// </summary>
        public readonly IList<ActionBase> Actions = new List<ActionBase>();

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.With; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
