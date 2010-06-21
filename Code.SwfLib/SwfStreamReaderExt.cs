using System;
using Code.SwfLib.Data;

namespace Code.SwfLib {
    public static class SwfStreamReaderExt {

        public static SwfFileInfo ReadSwfFileInfo(this SwfStreamReader writer)
        {
            SwfFileInfo header;
            header.Format = new string(new[] {(char)writer.ReadByte(), (char)writer.ReadByte(), (char)writer.ReadByte()});
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
            header.FrameRate = reader.ReadFixedPoint16();
            header.FrameCount = reader.ReadUInt16();
            return header;
        }

        public static SwfRect ReadRect(this SwfStreamReader reader) {
            var bits = (uint)reader.ReadUnsignedBits(5);
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
            var matrix = new SwfMatrix();
            var hasScale = reader.ReadBit();
            if (hasScale) {
                var bits = (byte)reader.ReadUnsignedBits(5);
                //TODO: check boundaries
                matrix.ScaleX = reader.ReadSignedBits(bits);
                matrix.ScaleY = reader.ReadSignedBits(bits);
            } else {
                matrix.ScaleX = 1;
                matrix.ScaleY = 1;
            }
            var hasRotate = reader.ReadBit();
            if (hasRotate) {
                var bits = (byte)reader.ReadUnsignedBits(5);
                //TODO: check boundaries
                matrix.RotateSkew0 = reader.ReadSignedBits(bits);
                matrix.RotateSkew1 = reader.ReadSignedBits(bits);
            } else {
                matrix.RotateSkew0 = 0;
                matrix.RotateSkew1 = 0;
            }
            var translateBits = (byte)reader.ReadUnsignedBits(5);
            //TODO: check boundaries
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

        public static SwfTextRecord ReadTextRecord(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            //TODO: for definetext2 a little bit different.
            var res = new SwfTextRecord();
            byte btFlags;
            do {
                btFlags = reader.ReadByte();
                if (btFlags == 0) {
                    res.Entries.Add(new SwfTextRecordEndEntry());
                } else if (btFlags >= 0x80) {
                    var setupRecord = new SwfTextRecordSetupEntry();
                    SwfTextRecordSetupEntryFlags flags;
                    flags = (SwfTextRecordSetupEntryFlags)btFlags;
                    setupRecord.FontID = (flags & SwfTextRecordSetupEntryFlags.HasFont) != 0
                                             ? (ushort?)reader.ReadUInt16()
                                             : null;
                    setupRecord.RGB = (flags & SwfTextRecordSetupEntryFlags.HasColor) != 0
                                          ? (SwfRGB?)reader.ReadRGB()
                                          : null;

                    setupRecord.MoveX = (flags & SwfTextRecordSetupEntryFlags.HasMoveX) != 0
                                            ? (ushort?)reader.ReadUInt16()
                                            : null;
                    setupRecord.MoveY = (flags & SwfTextRecordSetupEntryFlags.HasMoveY) != 0
                                            ? (ushort?)reader.ReadUInt16()
                                            : null;
                    setupRecord.FontHeight = (flags & SwfTextRecordSetupEntryFlags.HasFont) != 0
                                                 ? (ushort?)reader.ReadUInt16()
                                                 : null;
                    res.Entries.Add(setupRecord);
                } else {
                    var glyphRecord = new SwfTextRecordGlyphEntry();
                    var count = btFlags & 0x7f;
                    for (var i = 0; i < count; i++) {
                        var entry = reader.ReadSwfTextEntry(glyphBits, advanceBits);
                        glyphRecord.Glyphs.Add(entry);
                    }
                    res.Entries.Add(glyphRecord);
                    reader.AlignToByte();
                }
            } while (btFlags != 0);
            return res;
        }

        private static SwfTextEntry ReadSwfTextEntry(this SwfStreamReader reader, uint glyphBits, uint advanceBits) {
            var entry = new SwfTextEntry {
                Index = reader.ReadUnsignedBits(glyphBits),
                Advance = reader.ReadUnsignedBits(advanceBits)
            };
            return entry;
        }

    }
}