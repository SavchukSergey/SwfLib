using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : SwfTagBase {

        public ushort ShapeID;

        public SwfRect ShapeBounds;

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}