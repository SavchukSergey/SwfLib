namespace Code.SwfLib.Tags {
    public class UnknownTag : SwfTagBase {

        private SwfTagType _type;
        public byte[] Data;

        public UnknownTag() {
        }

        public UnknownTag(SwfTagType type) {
            _type = type;
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override SwfTagType TagType {
            get {
                return _type;
            }
        }

        public void SetTagType(SwfTagType type) {
            _type = type;
        }

    }
}
