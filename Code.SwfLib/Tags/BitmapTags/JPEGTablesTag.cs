namespace Code.SwfLib.Tags.BitmapTags {
    public class JPEGTablesTag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.JPEGTables; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
