namespace Code.SwfLib.Tags.ButtonTags {
    public class DefineButton2Tag : DefineButtonBaseTag {

        public byte ReservedFlags;

        public bool TrackAsMenu;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineButton2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
