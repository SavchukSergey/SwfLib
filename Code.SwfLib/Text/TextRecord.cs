using System.Collections.Generic;
using Code.SwfLib.Data;

namespace Code.SwfLib.Text {
    public class TextRecord {

        public bool Type;

        public byte Reserved { get; set; }

        public bool IsEnd {
            get { return !Type && Reserved == 0; }
        }

        public ushort? FontID;

        public SwfRGB? TextColor;

        public short? XOffset;

        public short? YOffset;

        public ushort? TextHeight;

        public readonly IList<GlyphEntry> Glyphs = new List<GlyphEntry>();

    }
}