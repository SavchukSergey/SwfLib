namespace Code.SwfLib.Tags.ShapeMorphingTags {
    public class DefineMorphShape2Tag : ShapeMorphingBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineMorphShape2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
