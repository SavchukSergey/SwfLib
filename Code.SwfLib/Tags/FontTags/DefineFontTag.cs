namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontTag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
