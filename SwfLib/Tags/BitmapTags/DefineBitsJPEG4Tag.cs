namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG4Tag : DefineBitsJpegAlphaBase {

        public ushort DeblockParam;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}