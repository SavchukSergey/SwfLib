using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;

namespace Code.SwfLib.Tags.ShapeTags {
    public abstract class ShapeBaseTag : SwfTagBase {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

        public readonly IList<FillStyle> FillStyles = new List<FillStyle>();

    }
}
