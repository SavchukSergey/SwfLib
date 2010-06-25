using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObjectTag : SwfTagBase {

        public ushort CharacterID;

        public ushort Depth;

        public SwfMatrix Matrix;

        public ColorTransformRGB? ColorTransform;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
