using System.Collections.Generic;

namespace SwfLib.Actions {
    /// <summary>
    /// Represents DefineFunction2 action.
    /// </summary>
    public class ActionDefineFunction2 : ActionBase {

        /// <summary>
        /// Gets or sets function name.
        /// </summary>
        public string Name { get; set; }

        public byte RegisterCount { get; set; }

        public bool PreloadParent { get; set; }

        public bool PreloadRoot { get; set; }

        public bool SuppressSuper { get; set; }

        public bool PreloadSuper { get; set; }

        public bool SuppressArguments { get; set; }

        public bool PreloadArguments { get; set; }

        public bool SuppressThis { get; set; }

        public bool PreloadThis { get; set; }

        public byte Reserved { get; set; }

        public bool PreloadGlobal { get; set; }

        public readonly IList<RegisterParam> Parameters = new List<RegisterParam>();

        /// <summary>
        /// Gets list of actions.
        /// </summary>
        public readonly List<ActionBase> Actions = new List<ActionBase>();

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.DefineFunction2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
