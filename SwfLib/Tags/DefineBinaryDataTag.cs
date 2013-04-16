using Code.SwfLib.Tags;

namespace SwfLib.Tags {
    public class DefineBinaryDataTag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBinaryData; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
