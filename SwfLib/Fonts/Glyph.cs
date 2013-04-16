using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.Fonts {
    public class Glyph {

        public ushort Code;

        public short Advance;

        public SwfRect Bounds;

        public readonly IList<IShapeRecordRGB> Records = new List<IShapeRecordRGB>();

    }
}
