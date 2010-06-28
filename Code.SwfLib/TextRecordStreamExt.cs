using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Data.Text;

namespace Code.SwfLib {
    public static class TextRecordStreamExt {

        public static void WriteTextRecord(this SwfStreamWriter writer, TextRecord record, uint glyphBits, uint advanceBits) {
            if (record == null) throw new ArgumentNullException("record");
            TextRecordFlags flags = record.Flags;
            writer.WriteByte((byte)flags);
            if (flags == 0) return;
            if (record.HasFont) {
                writer.WriteUInt16(record.FontID.Value);
            }
            if (record.HasColor) {
                var color = record.TextColor.Value;
                writer.WriteRGB(ref color);
            }
            if (record.HasXOffset) {
                writer.WriteSInt16(record.XOffset.Value);
            }
            if (record.HasYOffset) {
                writer.WriteSInt16(record.YOffset.Value);
            }
            if (record.HasFont) {
                if (!record.TextHeight.HasValue)
                    throw new InvalidOperationException("Font height must be specified when font is specified");
                writer.WriteUInt16(record.TextHeight.Value);
            }
            if (record.Glyphs.Count > 255)
                throw new InvalidOperationException("Text record has too much glyphs specified");

            writer.WriteByte((byte)record.Glyphs.Count);
            for (var i = 0; i < record.Glyphs.Count; i++) {
                var glyph = record.Glyphs[i];
                writer.WriteUnsignedBits(glyph.GlyphIndex, glyphBits);
                writer.WriteSignedBits(glyph.GlyphAdvance, advanceBits);
            }
        }

        public static GlyphEntry ReadGlyphEntry(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var entry = new GlyphEntry {
                GlyphIndex = reader.ReadUnsignedBits(glyphBits),
                GlyphAdvance = reader.ReadSignedBits(advanceBits)
            };
            return entry;
        }


    }
}
