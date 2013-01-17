namespace Code.SwfLib.Tags.SoundTags {
    public class SoundStreamHead2Tag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.SoundStreamHead2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
