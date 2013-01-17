namespace Code.SwfLib.Tags.VideoTags {
    public class VideoFameTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.VideoFrame; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
