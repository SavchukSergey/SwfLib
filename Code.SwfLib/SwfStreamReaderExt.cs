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

        public static ColorTransformRGB ReadColorTransformRGB(this SwfStreamReader reader) {
            ColorTransformRGB transform;
            reader.AlignToByte();
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedMultTerm = null;
                transform.GreenMultTerm = null;
                transform.BlueMultTerm = null;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedAddTerm = null;
                transform.GreenAddTerm = null;
                transform.BlueAddTerm = null;
            }
            return transform;
        }

        public static ColorTransformRGBA ReadColorTransformRGBA(this SwfStreamReader reader) {
            ColorTransformRGBA transform;
            reader.AlignToByte();
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.AlphaMultTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedMultTerm = null;
                transform.GreenMultTerm = null;
                transform.BlueMultTerm = null;
                transform.AlphaMultTerm = null;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.AlphaAddTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedAddTerm = null;
                transform.GreenAddTerm = null;
                transform.BlueAddTerm = null;
                transform.AlphaAddTerm = null;
            }
            return transform;
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
                    record.TextColor = hasColor ? (SwfRGB?)reader.ReadRGB() : null;
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