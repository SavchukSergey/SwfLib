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
            reader.ReadRect(out header.FrameSize);
            header.FrameRate = reader.ReadFixedPoint8();
            header.FrameCount = reader.ReadUInt16();
            return header;
        }

        public static void ReadRGB(this SwfStreamReader reader, out SwfRGB color) {
            color.Red = reader.ReadByte();
            color.Green = reader.ReadByte();
            color.Blue = reader.ReadByte();
        }

        public static void ReadRGBA(this SwfStreamReader reader, out SwfRGBA color) {
            color.Red = reader.ReadByte();
            color.Green = reader.ReadByte();
            color.Blue = reader.ReadByte();
            color.Alpha = reader.ReadByte();
        }

        public static SwfRGBA ReadARGB(this SwfStreamReader reader) {
            var rgb = new SwfRGBA {
                Alpha = reader.ReadByte(),
                Red = reader.ReadByte(),
                Green = reader.ReadByte(),
                Blue = reader.ReadByte()
            };
            return rgb;
        }

        public static void ReadRect(this SwfStreamReader reader, out SwfRect rect) {
            var bits = reader.ReadUnsignedBits(5);
            rect.XMin = reader.ReadSignedBits(bits);
            rect.XMax = reader.ReadSignedBits(bits);
            rect.YMin = reader.ReadSignedBits(bits);
            rect.YMax = reader.ReadSignedBits(bits);
        }

        public static void ReadMatrix(this SwfStreamReader reader, out SwfMatrix matrix) {
            reader.AlignToByte();
            matrix.HasScale = reader.ReadBit();
            if (matrix.HasScale) {
                var bits = (byte)reader.ReadUnsignedBits(5);
                matrix.ScaleX = reader.ReadFixedPoint16(bits);
                matrix.ScaleY = reader.ReadFixedPoint16(bits);
            } else {
                matrix.ScaleX = 1;
                matrix.ScaleY = 1;
            }
            matrix.HasRotate = reader.ReadBit();
            if (matrix.HasRotate) {
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
        }


        public static SwfSymbolReference ReadSymbolReference(this SwfStreamReader reader) {
            return new SwfSymbolReference {
                SymbolID = reader.ReadUInt16(),
                SymbolName = reader.ReadString()
            };

        }

        public static IList<TextRecord> ReadTextRecord(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var res = new List<TextRecord>();
            bool isEnd;
            do {
                var record = new TextRecord();
                bool type = reader.ReadBit();
                uint reservedFlags = reader.ReadUnsignedBits(3);
                bool hasFont = reader.ReadBit();
                bool hasColor = reader.ReadBit();
                bool hasYOffset = reader.ReadBit();
                bool hasXOffset = reader.ReadBit();

                isEnd = !(type || (reservedFlags != 0) || hasFont || hasColor || hasYOffset || hasXOffset);

                if (!isEnd) {
                    record.FontID = hasFont ? (ushort?)reader.ReadUInt16() : null;
                    if (hasColor) {
                        SwfRGB color;
                        reader.ReadRGB(out color);
                        record.TextColor = color;
                    } else {
                        record.TextColor = null;
                    }
                    record.XOffset = hasXOffset ? (short?)reader.ReadSInt16() : null;
                    record.YOffset = hasYOffset ? (short?)reader.ReadSInt16() : null;
                    record.TextHeight = hasFont ? (ushort?)reader.ReadUInt16() : null;
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


    }
}