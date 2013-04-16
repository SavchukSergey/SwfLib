namespace SwfLib.Tags.ControlTags {
    public class MetadataTag : ControlBaseTag {

        public string Metadata;

        public override SwfTagType TagType {
            get { return SwfTagType.Metadata; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}