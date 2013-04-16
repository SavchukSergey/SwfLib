using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public abstract class ShapeBaseTag : SwfTagBase {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

    }
}
