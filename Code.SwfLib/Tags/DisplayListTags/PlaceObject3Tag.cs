namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObject3Tag : DisplayListBaseTag {

        public ushort ObjectID;

        public string Name;

        public byte BitmapCache;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}