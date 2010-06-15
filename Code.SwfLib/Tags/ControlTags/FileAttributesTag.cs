namespace Code.SwfLib.Tags.ControlTags
{
    public class FileAttributesTag : ControlBaseTag {

        public SwfFileAttributes Attributes;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}