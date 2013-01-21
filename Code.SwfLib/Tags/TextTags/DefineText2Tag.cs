namespace Code.SwfLib.Tags.TextTags {
    public class DefineText2Tag : TextBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineText2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
