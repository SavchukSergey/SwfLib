using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ControlTags {
    public class SymbolClassTag : ControlBaseTag {

        public SwfSymbolReference[] References;

        public override SwfTagType TagType {
            get { return SwfTagType.SymbolClass; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}