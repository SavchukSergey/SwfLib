using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public abstract class ActionBase {

        public abstract ActionCode ActionCode { get; }

        public abstract object AcceptVisitor(IActionVisitor visitor);

    }
}
