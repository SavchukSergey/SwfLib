namespace SwfLib.Tags.BitmapTags
{
#if NETFULL
    /// <summary>
    /// Represents DefineBitsJPEG2 tag.
    /// </summary>
    public class DefineBitsJPEG2Tag : DefineBitsJpegTagBase {

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG2; }
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