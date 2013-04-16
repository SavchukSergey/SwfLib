namespace SwfLib.Actions {
    public class ActionMBAsciiToChar : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.MBAsciiToChar; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
