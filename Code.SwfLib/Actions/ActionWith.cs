namespace Code.SwfLib.Actions {
    public class ActionWith : ActionBase {
        
        //TODO: there is no sense in this field... Wouldn't usefull to have list of actions
        public ushort Size;

        public override ActionCode ActionCode {
            get { return ActionCode.With; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
