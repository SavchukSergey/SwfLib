namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsLosslessTag : DefineBitsBaseTag {

        public ushort CharacterID;

        //TODO: Enum
        public byte BitmapFormat;

        public ushort BitmapWidth;

        public ushort BitmapHeight;

        public byte BitmapColorTableSize;

        public byte[] ZlibBitmapData;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}