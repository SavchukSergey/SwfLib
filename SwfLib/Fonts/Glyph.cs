using System.Collections.Generic;
using SwfLib.Data;
using SwfLib.Shapes.Records;

namespace SwfLib.Fonts {
    public class Glyph {

        public ushort Code;

        public short Advance;

        public SwfRect Bounds;

        public readonly IList<IShapeRecordRGB> Records = new List<IShapeRecordRGB>();

    }
}
