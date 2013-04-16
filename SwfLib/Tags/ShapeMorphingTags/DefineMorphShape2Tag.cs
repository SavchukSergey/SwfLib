namespace Code.SwfLib.Tags.ShapeMorphingTags {
    public class DefineMorphShape2Tag : ShapeMorphingBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineMorphShape2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
