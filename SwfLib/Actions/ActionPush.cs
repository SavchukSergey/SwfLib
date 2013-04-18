using System.Collections.Generic;

namespace SwfLib.Actions {
    /// <summary>
    /// Represents Push action.
    /// </summary>
    public class ActionPush : ActionBase {

        /// <summary>
        /// Gets items to be pushed to stack.
        /// </summary>
        public readonly IList<ActionPushItem> Items = new List<ActionPushItem>();

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.Push; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
