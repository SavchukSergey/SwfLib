namespace SwfLib.Tags {
    public class DebugIDTag : SwfTagBase {

        public byte[] Data { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.DebugID; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}