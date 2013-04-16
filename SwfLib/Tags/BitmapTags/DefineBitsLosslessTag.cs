namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsLosslessTag : BitmapBaseTag {

        //TODO: Enum
        public byte BitmapFormat;

        public ushort BitmapWidth;

        public ushort BitmapHeight;

        public byte BitmapColorTableSize;

        public byte[] ZlibBitmapData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}