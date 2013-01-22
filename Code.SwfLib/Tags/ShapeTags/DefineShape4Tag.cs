namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape4Tag : ShapeBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}