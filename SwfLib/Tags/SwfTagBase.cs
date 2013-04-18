namespace SwfLib.Tags {
    /// <summary>
    /// Represents base class for all swf tags.
    /// </summary>
    public abstract class SwfTagBase {

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public abstract SwfTagType TagType { get; }

        /// <summary>
        /// Gets or sets rest data that is not parsed into properties.
        /// </summary>
        public byte[] RestData;

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public abstract TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg);

    }
}
