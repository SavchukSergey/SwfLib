namespace Code.SwfLib.Tags.ControlTags {
    public class EnableDebuggerTag : ControlBaseTag {
        
        public override SwfTagType TagType {
            get { return SwfTagType.EnableDebugger; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
