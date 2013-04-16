namespace SwfLib.Actions {
    public class ActionUnknown : ActionBase {

        private ActionCode _type;
        public byte[] Data;

        public ActionUnknown() {
        }

        public ActionUnknown(ActionCode type) {
            _type = type;
        }

        public override ActionCode ActionCode {
            get { return _type; }
        }

        public void SetActionCode(ActionCode type) {
            _type = type;
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
