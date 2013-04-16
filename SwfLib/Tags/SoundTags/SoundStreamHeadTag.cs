namespace SwfLib.Tags.SoundTags {
    public class SoundStreamHeadTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.SoundStreamHead; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
