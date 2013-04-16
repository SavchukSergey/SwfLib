namespace SwfLib.Tags.FontTags {
    public class DefineFont2Tag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
