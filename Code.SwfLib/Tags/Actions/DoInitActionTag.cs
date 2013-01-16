namespace Code.SwfLib.Tags.Actions {
    public class DoInitActionTag : SwfTagBase {

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