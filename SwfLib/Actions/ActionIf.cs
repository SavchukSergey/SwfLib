namespace SwfLib.Actions {
    /// <summary>
    /// Represents If action.
    /// </summary>
    public class ActionIf : ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.If;}
        }

        public short BranchOffset { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
