namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG4Tag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG4; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}