namespace SwfLib.Actions {
    /// <summary>
    /// Represents StoreRegister action.
    /// </summary>
    public class ActionStoreRegister : ActionBase {

        /// <summary>
        /// Gets or sets register number;
        /// </summary>
        public byte RegisterNumber { get; set; }

        /// <summary>
        /// Gets code of action.
        /// </summary>
        public override ActionCode ActionCode {
            get { return ActionCode.StoreRegister; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
