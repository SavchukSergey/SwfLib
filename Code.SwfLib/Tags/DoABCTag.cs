namespace Code.SwfLib.Tags {
    public class DoABCTag : SwfTagBase {

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoAbc; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}