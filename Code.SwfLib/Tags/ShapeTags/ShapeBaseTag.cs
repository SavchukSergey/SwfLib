using Code.SwfLib.Data;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib.Tags.ShapeTags {
    public abstract class ShapeBaseTag : SwfTagBase {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

        public readonly ShapeRecords1List ShapeRecords = new ShapeRecords1List();

    }
}
