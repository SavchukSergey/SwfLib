namespace Code.SwfLib.Tags.ControlTags {
    public class MetadataTag : ControlBaseTag {

        public string Metadata;

        public override SwfTagType TagType {
            get { return SwfTagType.Metadata; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}