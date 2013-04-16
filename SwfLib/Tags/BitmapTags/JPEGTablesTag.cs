using SwfLib.Tags;

namespace Code.SwfLib.Tags.BitmapTags {
    public class JPEGTablesTag : SwfTagBase {

        public byte[] JPEGData;

        public override SwfTagType TagType {
            get { return SwfTagType.JPEGTables; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
