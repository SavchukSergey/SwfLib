namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape3Tag : ShapeBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}