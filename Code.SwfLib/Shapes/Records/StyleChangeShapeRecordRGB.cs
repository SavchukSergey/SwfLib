using System.Collections.Generic;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordRGB : StyleChangeShapeRecord, IShapeRecordRGB {

        public readonly IList<FillStyleRGB> FillStyles = new List<FillStyleRGB>();

        public readonly IList<LineStyleRGB> LineStyles = new List<LineStyleRGB>();

    }
}
