namespace Code.SwfLib.Tags.SoundTags {
    public class SoundStreamBlockTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.SoundStreamBlock; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
