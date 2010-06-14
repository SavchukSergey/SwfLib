using System.Collections.Generic;

namespace Code.SwfLib.Data
{
    public class SwfTextRecordGlyphEntry : SwfTextRecordEntry
    {

        public readonly IList<SwfTextEntry> Glyphs = new List<SwfTextEntry>();

    }
}
