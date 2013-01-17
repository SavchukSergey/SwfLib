namespace Code.SwfLib.Tags.DisplayListTags {
    public class RemoveObjectTag : DisplayListBaseTag {

        public ushort CharacterID;

        public ushort Depth;

        public override SwfTagType TagType {
            get { return SwfTagType.RemoveObject; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
