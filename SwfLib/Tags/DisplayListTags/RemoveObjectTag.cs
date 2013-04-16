using SwfLib.Tags;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class RemoveObjectTag : DisplayListBaseTag {

        public ushort CharacterID;

        public ushort Depth;

        public override SwfTagType TagType {
            get { return SwfTagType.RemoveObject; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
