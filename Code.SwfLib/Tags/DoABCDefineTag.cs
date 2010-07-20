namespace Code.SwfLib.Tags {
    public class DoABCDefineTag : SwfTagBase {

        public uint Flags;

        public string Name;

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoAbcDefine; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}