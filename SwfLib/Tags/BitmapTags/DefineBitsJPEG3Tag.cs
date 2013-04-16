using Code.SwfLib.Tags;
using Code.SwfLib.Tags.BitmapTags;

namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG3Tag : DefineBitsJpegAlphaBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}