namespace Code.SwfLib.Tags.VideoTags {
    public class VideoFrameTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.VideoFrame; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
