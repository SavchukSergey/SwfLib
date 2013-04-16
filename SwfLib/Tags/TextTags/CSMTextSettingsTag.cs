namespace SwfLib.Tags.TextTags {
    public class CSMTextSettingsTag : TextBaseTag {

        public ushort TextID;

        public byte UseFlashType;

        public byte GridFit;

        public byte ReservedFlags;

        public float Thickness;

        public float Sharpness;

        public byte Reserved;

        public override SwfTagType TagType {
            get { return SwfTagType.CSMTextSettings; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}