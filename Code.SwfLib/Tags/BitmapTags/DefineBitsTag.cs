namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsTag : BitmapBaseTag {

        public byte[] JPEGData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBits; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
