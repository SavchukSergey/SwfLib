namespace SwfLib.Tags.FontTags {
    public class DefineFont4Tag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
