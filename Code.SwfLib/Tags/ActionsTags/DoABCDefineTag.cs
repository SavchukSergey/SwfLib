namespace Code.SwfLib.Tags.ActionsTags {
    public class DoABCDefineTag : ActionsBaseTag {

        public byte[] ABCData;

        public override SwfTagType TagType {
            get { return SwfTagType.DoABCDefine; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}