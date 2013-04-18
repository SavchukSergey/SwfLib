using System.Collections.Generic;

namespace SwfLib.Actions {
    /// <summary>
    /// Represents Try action.
    /// </summary>
    public class ActionTry : ActionBase {

        public byte Reserved { get; set; }

        public bool CatchInRegister { get; set; }

        public bool FinallyBlock { get; set; }

        public bool CatchBlock { get; set; }

        public string CatchName { get; set; }

        public byte CatchRegister { get; set; }

        public readonly IList<ActionBase> Try = new List<ActionBase>();

        public readonly IList<ActionBase> Catch = new List<ActionBase>();

        public readonly IList<ActionBase> Finally = new List<ActionBase>();

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.Try; }
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
