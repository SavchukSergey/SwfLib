namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObject3Tag : PlaceObjectBaseTag {

        public string Name;

        public byte BitmapCache;

        public bool HasCharacter;

        public bool HasMatrix;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}