namespace Code.SwfLib.Tags.ControlTags {
    public class EndTag : ControlBaseTag {
        public override SwfTagType TagType {
            get { return SwfTagType.End; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}