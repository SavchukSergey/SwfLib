using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObjectTag : DisplayListBaseTag {

        public ushort CharacterID;

        public ushort Depth;

        public SwfMatrix Matrix;

        public ColorTransformRGB? ColorTransform;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
