namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG2Tag : DefineBitsJpegTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}