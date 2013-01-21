namespace Code.SwfLib.Tags.BitmapTags {
    public class JPEGTablesTag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.JPEGTables; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
