namespace SwfLib.Actions {
    public class ActionStopSounds : ActionBase {
        public override ActionCode ActionCode {
            get { return ActionCode.StopSounds; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
