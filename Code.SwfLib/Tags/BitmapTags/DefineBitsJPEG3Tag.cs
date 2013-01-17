namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG3Tag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG3; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}