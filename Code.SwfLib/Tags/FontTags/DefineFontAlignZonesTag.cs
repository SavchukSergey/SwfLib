namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontAlignZonesTag : SwfTagBase {

        public ushort FontID;

        public byte[] Data;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontAlignZones; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}