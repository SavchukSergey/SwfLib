namespace Code.SwfLib.Tags.ActionsTags {
    public class DoABCTag : ActionsBaseTag {

        public uint Flags;

        public string Name;

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoAbc; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}