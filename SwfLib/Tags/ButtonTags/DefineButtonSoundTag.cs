using SwfLib.Tags;
using SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.Tags.ButtonTags {
    public class DefineButtonSoundTag : DefineButtonBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineButtonSound; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
