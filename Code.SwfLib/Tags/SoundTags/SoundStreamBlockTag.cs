namespace Code.SwfLib.Tags.SoundTags {
    public class SoundStreamBlockTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.SoundStreamBlock; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
