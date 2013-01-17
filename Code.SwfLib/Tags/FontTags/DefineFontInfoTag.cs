namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontInfoTag : FontBaseTag {

        public ushort FontId;

        public byte[] RestData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontInfo; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
