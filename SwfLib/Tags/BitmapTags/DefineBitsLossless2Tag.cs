namespace SwfLib.Tags.BitmapTags {
    public class DefineBitsLossless2Tag : BitmapBaseTag {
        
        public byte BitmapFormat { get; set; }

        public ushort BitmapWidth { get; set; }

        public ushort BitmapHeight { get; set; }

        public byte BitmapColorTableSize;

        public byte[] ZlibBitmapData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}