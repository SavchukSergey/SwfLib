namespace SwfLib.Tags.ShapeMorphingTags {
    public class DefineMorphShapeTag : ShapeMorphingBaseTag {

        public ushort CharacterID { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.DefineMorphShape; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
