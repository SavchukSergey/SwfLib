using System.Diagnostics;

namespace SwfLib.Text {
    [DebuggerDisplay("GlyphIndex = {GlyphIndex}, GlyphAdvance = {GlyphAdvance}")]
    public struct GlyphEntry {
        public uint GlyphIndex;

        public int GlyphAdvance;

    }
}