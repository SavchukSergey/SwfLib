namespace Code.SwfLib.Tags.ControlTags {
    public class FrameLabelTag : ControlBaseTag {
        
        public byte AnchorFlag;

        public string Name { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.FrameLabel; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}