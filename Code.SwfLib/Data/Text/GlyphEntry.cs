using System.Diagnostics;

namespace Code.SwfLib.Data.Text {
    [DebuggerDisplay("GlyphIndex = {GlyphIndex}, GlyphAdvance = {GlyphAdvance}")]
    public struct GlyphEntry {
        public uint GlyphIndex;

        public int GlyphAdvance;

    }
}