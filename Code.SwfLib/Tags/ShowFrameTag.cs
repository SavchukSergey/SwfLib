namespace Code.SwfLib.Tags {
    public class ShowFrameTag : SwfTagBase {
        public override SwfTagType TagType {
            get { return SwfTagType.ShowFrame; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
