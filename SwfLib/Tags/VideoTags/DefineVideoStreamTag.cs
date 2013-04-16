namespace SwfLib.Tags.VideoTags {
    public class DefineVideoStreamTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineVideoStream; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
