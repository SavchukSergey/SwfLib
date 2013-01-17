namespace Code.SwfLib.Tags.ControlTags {
    public class SetTabIndexTag : ControlBaseTag {
        
        public override SwfTagType TagType {
            get { return SwfTagType.SetTabIndex; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
