namespace Code.SwfLib.Tags.ActionsTags {
    public class DoABCDefineTag : ActionsBaseTag {

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoAbcDefine; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}