namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsLossless2Tag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}