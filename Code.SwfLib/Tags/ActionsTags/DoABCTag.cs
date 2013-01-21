namespace Code.SwfLib.Tags.ActionsTags {
    public class DoABCTag : ActionsBaseTag {

        public uint Flags;

        public string Name;

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoABC; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}