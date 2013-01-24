namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG3Tag : BitmapBaseTag {

        public byte[] ImageData;

        public byte[] BitmapAlphaData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}