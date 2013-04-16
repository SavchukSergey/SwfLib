using System.Collections.Generic;
using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionTry : ActionBase
    {

        public byte Reserved;

        public bool CatchInRegister;

        public bool FinallyBlock;

        public bool CatchBlock;

        public string CatchName;

        public byte CatchRegister;

        public readonly IList<ActionBase> Try = new List<ActionBase>();

        public readonly IList<ActionBase> Catch = new List<ActionBase>();

        public readonly IList<ActionBase> Finally = new List<ActionBase>();

        public override ActionCode ActionCode {
            get { return ActionCode.Try; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
