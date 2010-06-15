namespace Code.SwfLib.Tags {
    public class FileAttributesTag : SwfTagBase {

        public SwfFileAttributes Attributes;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }

}