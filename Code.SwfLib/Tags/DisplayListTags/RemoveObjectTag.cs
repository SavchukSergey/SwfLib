namespace Code.SwfLib.Tags.DisplayListTags {
    public class RemoveObjectTag : SwfTagBase {

        public ushort CharacterID;

        public ushort Depth;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
