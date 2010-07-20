namespace Code.SwfLib.Tags {
    public class DoInitActionTag : SwfTagBase {
        public override SwfTagType TagType {
            get { return SwfTagType.DoInitAction; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
