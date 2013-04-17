namespace SwfLib.Actions {
    /// <summary>
    /// Represents GetURL action.
    /// </summary>
    public class ActionGetURL : ActionBase {


        public string UrlString { get; set; }

        public string TargetString { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.GetURL; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
