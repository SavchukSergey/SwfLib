namespace SwfLib.Tags.BitmapTags
{
#if NETFULL
    /// <summary>
    /// Represents DefineBitsJPEG4 tag.
    /// </summary>
    public class DefineBitsJPEG4Tag : DefineBitsJpegAlphaBase {

        /// <summary>
        /// Gets or sets the deblock param.
        /// </summary>
        /// <value>
        /// The deblock param.
        /// </value>
        public ushort DeblockParam { get; set; }

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG4; }
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
#endif
}