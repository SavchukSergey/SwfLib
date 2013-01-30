namespace Code.SwfLib.Actions {
    public class ActionGotoFrame2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame2; }
        }

        public bool Play;

        public byte Reserved;

        public ushort? SceneBias { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
