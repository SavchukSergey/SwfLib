namespace Code.SwfLib.Tags.ActionsTags {
    public class DoInitActionTag : ActionsBaseTag {

        public ushort SpriteId;

        //TODO: expand into dom
        public byte[] RestData;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override SwfTagType TagType {
            get {
                return SwfTagType.DoInitAction;
            }
        }
    }
}