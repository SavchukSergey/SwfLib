namespace Code.SwfLib.Tags.ShapeMorphingTags {
    public class DefineMorphShapeTag : ShapeMorphingBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineMorphShape; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
