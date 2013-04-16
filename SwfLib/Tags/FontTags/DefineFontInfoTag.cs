using SwfLib.Tags;

namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontInfoTag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontInfo; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
