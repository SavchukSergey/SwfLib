using System;
using System.Collections.Generic;
using SwfLib.Data;

namespace SwfLib.Text {
    public static class TextStreamExt {

        public static IList<TextRecordRGB> ReadTextRecordsRGB(this ISwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var res = new List<TextRecordRGB>();
            bool isEnd;
            do {
                var record = new TextRecordRGB();
                record.Type = reader.ReadBit();
                record.Reserved = (byte)reader.ReadUnsignedBits(3);
                var hasFont = reader.ReadBit();
                var hasColor = reader.ReadBit();
                var hasYOffset = reader.ReadBit();
                var hasXOffset = reader.ReadBit();

                isEnd = !record.Type && record.Reserved == 0 && !hasFont && !hasColor && !hasYOffset && !hasXOffset;

                if (!isEnd) {
                    record.FontID = hasFont ? (ushort?)reader.ReadUInt16() : null;
                    if (hasColor) {
                        record.TextColor = reader.ReadRGB();
                    }
                    if (hasXOffset) {
                        record.XOffset = reader.ReadSInt16();
                    }
                    if (hasYOffset) {
                        record.YOffset = reader.ReadSInt16();
                    }
                    if (hasFont) {
                        record.TextHeight = reader.ReadUInt16();
                    }
                    var count = reader.ReadByte();
                    for (var i = 0; i < count; i++) {
                        var entry = reader.ReadGlyphEntry(glyphBits, advanceBits);
                        record.Glyphs.Add(entry);
                    }
                    reader.AlignToByte();
                }
                res.Add(record);
            } while (!isEnd);
            return res;
        }

        public static IList<TextRecordRGBA> ReadTextRecordsRGBA(this ISwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var res = new List<TextRecordRGBA>();
            bool isEnd;
            do {
                var record = new TextRecordRGBA();
                record.Type = reader.ReadBit();
                record.Reserved = (byte)reader.ReadUnsignedBits(3);
                var hasFont = reader.ReadBit();
                var hasColor = reader.ReadBit();
                var hasYOffset = reader.ReadBit();
                var hasXOffset = reader.ReadBit();

                isEnd = !record.Type && record.Reserved == 0 && !hasFont && !hasColor && !hasYOffset && !hasXOffset;

                if (!isEnd) {
                    record.FontID = hasFont ? (ushort?)reader.ReadUInt16() : null;
                    if (hasColor) {
                        record.TextColor = reader.ReadRGBA();
                    }
                    if (hasXOffset) {
                        record.XOffset = reader.ReadSInt16();
                    }
                    if (hasYOffset) {
                        record.YOffset = reader.ReadSInt16();
                    }
                    if (hasFont) {
                        record.TextHeight = reader.ReadUInt16();
                    }
                    var count = reader.ReadByte();
                    for (var i = 0; i < count; i++) {
                        var entry = reader.ReadGlyphEntry(glyphBits, advanceBits);
                        record.Glyphs.Add(entry);
                    }
                    reader.AlignToByte();
                }
                res.Add(record);
            } while (!isEnd);
            return res;
        }

        public static void WriteTextRecordRGB(this ISwfStreamWriter writer, TextRecordRGB record, uint glyphBits, uint advanceBits) {
            if (record == null) throw new ArgumentNullException("record");
            writer.WriteBit(record.Type);
            writer.WriteUnsignedBits(record.Reserved, 3);

            writer.WriteBit(record.FontID.HasValue);
            writer.WriteBit(record.TextColor.HasValue);
            writer.WriteBit(record.YOffset.HasValue);
            writer.WriteBit(record.XOffset.HasValue);

            var isEnd = !record.Type && record.Reserved == 0 && !record.FontID.HasValue && !record.TextColor.HasValue && !record.YOffset.HasValue && !record.XOffset.HasValue;

            if (!isEnd) {
                if (record.FontID.HasValue) {
                    writer.WriteUInt16(record.FontID.Value);
                }
                if (record.TextColor.HasValue) {
                    var color = record.TextColor.Value;
                    writer.WriteRGB(ref color);
                }
                if (record.XOffset.HasValue) {
                    writer.WriteSInt16(record.XOffset.Value);
                }
                if (record.YOffset.HasValue) {
                    writer.WriteSInt16(record.YOffset.Value);
                }
                if (record.FontID.HasValue) {
                    if (!record.TextHeight.HasValue)
                        throw new InvalidOperationException("Font height must be specified when font is specified");
                    writer.WriteUInt16(record.TextHeight.Value);
                }
                if (record.Glyphs.Count > 255)
                    throw new InvalidOperationException("Text record has too much glyphs specified");

                writer.WriteByte((byte)record.Glyphs.Count);
                foreach (var glyph in record.Glyphs) {
                    writer.WriteGlyphEntry(glyph, glyphBits, advanceBits);
                }
            }
            writer.FlushBits();
        }

        public static void WriteTextRecordRGBA(this ISwfStreamWriter writer, TextRecordRGBA record, uint glyphBits, uint advanceBits) {
            if (record == null) throw new ArgumentNullException("record");
            writer.WriteBit(record.Type);
            writer.WriteUnsignedBits(record.Reserved, 3);

            writer.WriteBit(record.FontID.HasValue);
            writer.WriteBit(record.TextColor.HasValue);
            writer.WriteBit(record.YOffset.HasValue);
            writer.WriteBit(record.XOffset.HasValue);

            var isEnd = !record.Type && record.Reserved == 0 && !record.FontID.HasValue && !record.TextColor.HasValue && !record.YOffset.HasValue && !record.XOffset.HasValue;

            if (!isEnd) {
                if (record.FontID.HasValue) {
                    writer.WriteUInt16(record.FontID.Value);
                }
                if (record.TextColor.HasValue) {
                    var color = record.TextColor.Value;
                    writer.WriteRGBA(ref color);
                }
                if (record.XOffset.HasValue) {
                    writer.WriteSInt16(record.XOffset.Value);
                }
                if (record.YOffset.HasValue) {
                    writer.WriteSInt16(record.YOffset.Value);
                }
                if (record.FontID.HasValue) {
                    if (!record.TextHeight.HasValue)
                        throw new InvalidOperationException("Font height must be specified when font is specified");
                    writer.WriteUInt16(record.TextHeight.Value);
                }
                if (record.Glyphs.Count > 255)
                    throw new InvalidOperationException("Text record has too much glyphs specified");

                writer.WriteByte((byte)record.Glyphs.Count);
                foreach (var glyph in record.Glyphs) {
                    writer.WriteGlyphEntry(glyph, glyphBits, advanceBits);
                }
            }
            writer.FlushBits();
        }


        public static GlyphEntry ReadGlyphEntry(this ISwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var entry = new GlyphEntry {
                GlyphIndex = reader.ReadUnsignedBits(glyphBits),
                GlyphAdvance = reader.ReadSignedBits(advanceBits)
            };
            return entry;
        }

        public static void WriteGlyphEntry(this ISwfStreamWriter writer, GlyphEntry glyph, uint glyphBits, uint advanceBits) {
            writer.WriteUnsignedBits(glyph.GlyphIndex, glyphBits);
            writer.WriteSignedBits(glyph.GlyphAdvance, advanceBits);
        }
    }
}
