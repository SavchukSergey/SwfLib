namespace Code.SwfLib.Actions {
    public class ActionGetURL2 : ActionBase {

        //TODO: split into separate flags
        public byte Flags;

        public override ActionCode ActionCode {
            get { return ActionCode.GetURL2; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
