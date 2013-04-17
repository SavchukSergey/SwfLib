namespace SwfLib.Actions {
    /// <summary>
    /// Represents base class for ActionScript 2.0 actions.
    /// </summary>
    public abstract class ActionBase {

        /// <summary>
        /// Gets ActionCode.
        /// </summary>
        public abstract ActionCode ActionCode { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg);

    }
}
