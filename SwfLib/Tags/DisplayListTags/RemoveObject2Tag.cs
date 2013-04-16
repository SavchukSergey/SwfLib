using SwfLib.Tags;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class RemoveObject2Tag : DisplayListBaseTag {

        public ushort Depth;

        public override SwfTagType TagType {
            get { return SwfTagType.RemoveObject2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}