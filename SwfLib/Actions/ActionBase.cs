using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public abstract class ActionBase {

        public abstract ActionCode ActionCode { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg);

    }
}
