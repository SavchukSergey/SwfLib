namespace Code.SwfLib.Tags {
    public class DefineBinaryDataTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBinaryData; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
