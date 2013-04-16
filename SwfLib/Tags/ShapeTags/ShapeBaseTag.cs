using Code.SwfLib.Data;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.ShapeTags {
    public abstract class ShapeBaseTag : SwfTagBase {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

    }
}
