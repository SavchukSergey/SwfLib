namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsTag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBits; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
