namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsLosslessTag : BitmapBaseTag {

        //TODO: Enum
        public byte BitmapFormat { get; set; }

        /// <summary>
        /// Gets or sets the width of the bitmap.
        /// </summary>
        /// <value>
        /// The width of the bitmap.
        /// </value>
        public ushort BitmapWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the bitmap.
        /// </summary>
        /// <value>
        /// The height of the bitmap.
        /// </value>
        public ushort BitmapHeight { get; set; }

        public byte BitmapColorTableSize { get; set; }

        public byte[] ZlibBitmapData { get; set; }

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless; }
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