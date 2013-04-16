namespace SwfLib.Tags.ControlTags {
    public class ImportAssets2Tag : ControlBaseTag {
        
        public override SwfTagType TagType {
            get { return SwfTagType.ImportAssets2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
