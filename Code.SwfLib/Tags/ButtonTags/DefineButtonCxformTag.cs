namespace Code.SwfLib.Tags.ButtonTags {
    public class DefineButtonCxformTag : SwfTagBase {
        public override SwfTagType TagType {
            get { return SwfTagType.DefineButtonCxform; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
