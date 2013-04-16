namespace Code.SwfLib.Tags.ButtonTags {
    public class DefineButtonTag : DefineButtonBaseTag {
        
        public override SwfTagType TagType {
            get { return SwfTagType.DefineButton; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
