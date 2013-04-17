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
        /// <typeparam name="TArg"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="visitor"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public abstract TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg);

    }
}
