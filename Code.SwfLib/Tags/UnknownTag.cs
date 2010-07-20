namespace Code.SwfLib.Tags {
    public class UnknownTag : SwfTagBase {

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        private SwfTagType _type;

        public override SwfTagType TagType {
            get {
                return _type;
            }
        }

        public void SetTagType(SwfTagType type) {
            _type = type;
        }

        public byte[] Data;
    }
}
