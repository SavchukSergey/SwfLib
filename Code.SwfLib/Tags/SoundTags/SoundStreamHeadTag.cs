namespace Code.SwfLib.Tags.SoundTags {
    public class SoundStreamHeadTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.SoundStreamHead; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
