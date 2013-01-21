namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontTag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
