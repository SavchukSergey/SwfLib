using System.Collections.Generic;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordRGBA : StyleChangeShapeRecord, IShapeRecordRGBA {

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleRGBA> LineStyles = new List<LineStyleRGBA>();

    }
}
