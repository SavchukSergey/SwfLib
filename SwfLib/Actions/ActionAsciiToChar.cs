namespace Code.SwfLib.Actions {
    public class ActionAsciiToChar : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.AsciiToChar; }
        }
        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
