using SwfLib.Data;

namespace SwfLib.Tags.ShapeTags {
    public abstract class ShapeBaseTag : SwfTagBase {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

    }
}
