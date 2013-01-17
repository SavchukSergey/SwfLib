namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontInfo2Tag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontInfo2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
