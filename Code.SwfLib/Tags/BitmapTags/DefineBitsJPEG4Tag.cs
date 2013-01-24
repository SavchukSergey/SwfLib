namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG4Tag : BitmapBaseTag {

        //TODO: read it
        public ushort CharacterID;
        
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}