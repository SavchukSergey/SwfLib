using System.Collections.Generic;
using SwfLib.Data;
using SwfLib.Shapes.Records;

namespace SwfLib.Fonts {
    /// <summary>
    /// Represents glyph.
    /// </summary>
    public class Glyph {

        /// <summary>
        /// Gets or sets glyph code.
        /// </summary>
        public ushort Code { get; set; }

        /// <summary>
        /// Gets or sets glyph advance value.
        /// </summary>
        public short Advance { get; set; }

        /// <summary>
        /// Gets or sets glyph boundaries.
        /// </summary>
        public SwfRect Bounds { get; set; }

        public readonly IList<IShapeRecordRGB> Records = new List<IShapeRecordRGB>();

    }
}
