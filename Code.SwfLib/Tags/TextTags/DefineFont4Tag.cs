namespace Code.SwfLib.Tags.TextTags {
    public class DefineFont4Tag : TextBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
