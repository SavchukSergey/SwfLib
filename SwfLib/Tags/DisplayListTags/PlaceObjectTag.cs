using Code.SwfLib.Data;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObjectTag : PlaceObjectBaseTag {

        public ColorTransformRGB? ColorTransform;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
