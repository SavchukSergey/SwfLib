namespace SwfLib.Tags {
    /// <summary>
    /// Represents tag that is unknown to the swflib.
    /// </summary>
    public class UnknownTag : SwfTagBase {

        private SwfTagType _type;
        public byte[] Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownTag"/> class.
        /// </summary>
        public UnknownTag() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownTag"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public UnknownTag(SwfTagType type) {
            _type = type;
        }

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return _type; }
        }

        /// <summary>
        /// Sets the type of the tag.
        /// </summary>
        /// <param name="type">The type.</param>
        public void SetTagType(SwfTagType type) {
            _type = type;
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="visitor"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
