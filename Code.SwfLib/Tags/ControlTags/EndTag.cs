namespace Code.SwfLib.Tags.ControlTags {
    public class EndTag : ControlBaseTag {
        public override SwfTagType TagType {
            get { return SwfTagType.End; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}