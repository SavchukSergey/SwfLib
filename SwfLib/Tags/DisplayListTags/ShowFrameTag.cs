namespace SwfLib.Tags.DisplayListTags {
    public class ShowFrameTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.ShowFrame; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
