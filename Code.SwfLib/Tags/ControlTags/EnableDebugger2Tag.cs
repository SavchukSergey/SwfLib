namespace Code.SwfLib.Tags.ControlTags {
    public class EnableDebugger2Tag : ControlBaseTag {

        public byte[] Data { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.EnableDebugger2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
