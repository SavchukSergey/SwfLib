using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : SwfTagBase {

        public ushort ObjectID;

        public SwfRect Bounds;

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}