namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontNameTag : FontBaseTag {

        public ushort FontId;

        public string FontName;

        public string FontCopyright;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontName; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
