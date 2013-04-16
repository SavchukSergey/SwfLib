using Code.SwfLib.Data;
using SwfLib;

namespace Code.SwfLib {
    public static class SwfStreamReaderExt {

        public static SwfFileInfo ReadSwfFileInfo(this ISwfStreamReader writer) {
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

        public static SwfHeader ReadSwfHeader(this ISwfStreamReader reader) {
            SwfHeader header;
            reader.ReadRect(out header.FrameSize);
            header.FrameRate = reader.ReadFixedPoint8();
            header.FrameCount = reader.ReadUInt16();
            return header;
        }

        public static SwfRect ReadRect(this ISwfStreamReader reader) {
            SwfRect rect;
            ReadRect(reader, out rect);
            return rect;
        }

        public static void ReadRect(this ISwfStreamReader reader, out SwfRect rect) {
            var bits = reader.ReadUnsignedBits(5);
            rect.XMin = reader.ReadSignedBits(bits);
            rect.XMax = reader.ReadSignedBits(bits);
            rect.YMin = reader.ReadSignedBits(bits);
            rect.YMax = reader.ReadSignedBits(bits);
            reader.AlignToByte();
        }

        public static SwfMatrix ReadMatrix(this ISwfStreamReader reader) {
            SwfMatrix matrix;
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
            return matrix;
        }


        public static SwfSymbolReference ReadSymbolReference(this ISwfStreamReader reader) {
            return new SwfSymbolReference {
                SymbolID = reader.ReadUInt16(),
                SymbolName = reader.ReadString()
            };

        }
    }
}