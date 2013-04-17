using System.Collections.Generic;

namespace SwfLib.Actions {
    /// <summary>
    /// Represents DefineFunction action.
    /// </summary>
    public class ActionDefineFunction : ActionBase {

        /// <summary>
        /// Gets or sets function name.
        /// </summary>
        public string Name { get; set; }

        public readonly IList<string> Args = new List<string>();

        /// <summary>
        /// Gets list of actions.
        /// </summary>
        public readonly List<ActionBase> Actions = new List<ActionBase>();

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.DefineFunction; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
