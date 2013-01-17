namespace Code.SwfLib.Tags.ShapeMorphingTags {
    public class DefineMorphShapeTag : ShapeMorphingBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineMorphShape; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
