namespace Code.SwfLib.Tags.VideoTags {
    public class VideoFrameTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.VideoFrame; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
