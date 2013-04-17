namespace SwfLib.Actions {
    /// <summary>
    /// Represents base class for ActionScript 2.0 actions.
    /// </summary>
    public abstract class ActionBase {

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public abstract ActionCode ActionCode { get; }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public abstract TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg);

    }
}
