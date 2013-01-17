namespace Code.SwfLib.Tags.ControlTags {
    public class DefineScalingGridTag : ControlBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineScalingGrid; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
