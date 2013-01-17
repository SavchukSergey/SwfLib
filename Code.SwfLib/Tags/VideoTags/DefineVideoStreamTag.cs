namespace Code.SwfLib.Tags.VideoTags {
    public class DefineVideoStreamTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineVideoStream; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
