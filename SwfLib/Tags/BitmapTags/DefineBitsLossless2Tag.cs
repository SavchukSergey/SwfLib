namespace SwfLib.Tags.BitmapTags {
    /// <summary>
    /// Represents DefineBitsLossless2 tag.
    /// </summary>
    public class DefineBitsLossless2Tag : BitmapBaseTag {
        
        public byte BitmapFormat { get; set; }

        public ushort BitmapWidth { get; set; }

        public ushort BitmapHeight { get; set; }

        public byte BitmapColorTableSize;

        public byte[] ZlibBitmapData;

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless2; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}