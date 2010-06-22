using System;
using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Text;

namespace Code.SwfLib {
    public static class SwfStreamReaderExt {

        public static SwfFileInfo ReadSwfFileInfo(this SwfStreamReader writer) {
            SwfFileInfo header;
            header.Format = new string(new[] { (char)writer.ReadByte(), (char)writer.ReadByte(), (char)writer.ReadByte() });
            header.Version = writer.ReadByte();
            uint len = 0;
            len = len | ((uint)writer.ReadByte() << 0);
            len = len | ((uint)writer.ReadByte() << 8);
            len = len | ((uint)writer.ReadByte() << 16);
            len = len | ((uint)writer.ReadByte() << 24);
            header.FileLength = len;
            return header;
        }

        public static SwfHeader ReadSwfHeader(this SwfStreamReader reader) {
            SwfHeader header;
            header.FrameSize = reader.ReadRect();
            header.FrameRate = reader.ReadFixedPoint8();
            header.FrameCount = reader.ReadUInt16();
            return header;
        }

        public static SwfRect ReadRect(this SwfStreamReader reader) {
            var bits = reader.ReadUnsignedBits(5);
            SwfRect rect;
            rect.XMin = reader.ReadSignedBits(bits);
            rect.XMax = reader.ReadSignedBits(bits);
            rect.YMin = reader.ReadSignedBits(bits);
            rect.YMax = reader.ReadSignedBits(bits);
            return rect;
        }

        public static SwfRGB ReadRGB(this SwfStreamReader reader) {
            var rgb = new SwfRGB {
                Red = reader.ReadByte(),
                Green = reader.ReadByte(),
                Blue = reader.ReadByte()
            };
            return rgb;
        }

        public static SwfMatrix ReadMatrix(this SwfStreamReader reader) {
            reader.AlignToByte();
            var matrix = new SwfMatrix();
            var hasScale = reader.ReadBit();
            if (hasScale) {
                var bits = (byte)reader.ReadUnsignedBits(5);
                matrix.ScaleX = reader.ReadFixedPoint16(bits);
                matrix.ScaleY = reader.ReadFixedPoint16(bits);
            } else {
                matrix.ScaleX = 1;
                matrix.ScaleY = 1;
            }
            var hasRotate = reader.ReadBit();
            if (hasRotate) {
                var bits = (byte)reader.ReadUnsignedBits(5);
                matrix.RotateSkew0 = reader.ReadFixedPoint16(bits);
                matrix.RotateSkew1 = reader.ReadFixedPoint16(bits);
            } else {
                matrix.RotateSkew0 = 0;
                matrix.RotateSkew1 = 0;
            }
            var translateBits = (byte)reader.ReadUnsignedBits(5);
            matrix.TranslateX = reader.ReadSignedBits(translateBits);
            matrix.TranslateY = reader.ReadSignedBits(translateBits);
            reader.AlignToByte();
            return matrix;
        }

        public static SwfColorTransform ReadColorTransform(this SwfStreamReader reader) {
            throw new NotImplementedException();
        }

        public static SwfSymbolReference ReadSymbolReference(this SwfStreamReader reader) {
            return new SwfSymbolReference {
                SymbolID = reader.ReadUInt16(),
                SymbolName = reader.ReadString()
            };

        }

        public static SwfAnyFilter ReadAnyFilter(this SwfStreamReader reader) {
            throw new NotImplementedException();
        }

        public static IList<TextRecord> ReadTextRecord(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var res = new List<TextRecord>();
            byte btFlags;
            do {
                var record = new TextRecord();
                btFlags = reader.ReadByte();
                TextRecordFlags flags;
                flags = (TextRecordFlags)btFlags;

                record.FontID = (flags & TextRecordFlags.HasFont) != 0
                                         ? (ushort?)reader.ReadUInt16()
                                         : null;
                record.TextColor = (flags & TextRecordFlags.HasColor) != 0
                                      ? (SwfRGB?)reader.ReadRGB()
                                      : null;

                record.XOffset = (flags & TextRecordFlags.HasXOffset) != 0
                                        ? (short?)reader.ReadUInt16()
                                        : null;
                record.YOffset = (flags & TextRecordFlags.HasYOffset) != 0
                                        ? (short?)reader.ReadUInt16()
                                        : null;
                record.TextHeight = (flags & TextRecordFlags.HasFont) != 0
                                             ? (ushort?)reader.ReadUInt16()
                                             : null;
                if (btFlags != 0) {
                    var count = reader.ReadByte();
                    for (var i = 0; i < count; i++) {
                        var entry = reader.ReadSwfTextEntry(glyphBits, advanceBits);
                        record.Glyphs.Add(entry);
                    }
                    reader.AlignToByte();
                }
                res.Add(record);
            } while (btFlags != 0);
            return res;
        }

        private static GlyphEntry ReadSwfTextEntry(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var entry = new GlyphEntry {
                GlyphIndex = reader.ReadUnsignedBits(glyphBits),
                GlyphAdvance = reader.ReadSignedBits(advanceBits)
            };
            return entry;
        }

    }
}