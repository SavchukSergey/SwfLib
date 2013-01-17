namespace Code.SwfLib.Tags.ButtonTags {
    public class DefineButtonSoundTag : SwfTagBase {
        public ushort ButtonID;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineButtonSound; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
