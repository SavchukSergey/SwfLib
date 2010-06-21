using System;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.LineStyles;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib {
    public static class SwfStreamWriterExt {

        public static void WriteSwfFileInfo(this SwfStreamWriter writer, SwfFileInfo fileInfo) {
            string format = fileInfo.Format;
            if (format == null || format.Length != 3)
                throw new InvalidOperationException("Format should be of length 3");
            writer.WriteByte((byte)format[0]);
            writer.WriteByte((byte)format[1]);
            writer.WriteByte((byte)format[2]);

            writer.WriteByte(fileInfo.Version);

            var len = fileInfo.FileLength;
            writer.WriteByte((byte)((len >> 0) & 0xff));
            writer.WriteByte((byte)((len >> 8) & 0xff));
            writer.WriteByte((byte)((len >> 16) & 0xff));
            writer.WriteByte((byte)((len >> 24) & 0xff));
        }

        public static void WriteSwfHeader(this SwfStreamWriter writer, SwfHeader header) {
            writer.WriteRect(header.FrameSize);
            writer.WriteFixedPoint16(header.FrameRate);
            writer.WriteUInt16(header.FrameCount);
        }

        public static void WriteRect(this SwfStreamWriter writer, SwfRect rect) {
            BitsCount btCount = new BitsCount(0);
            btCount.AddValue(rect.XMin);
            btCount.AddValue(rect.XMax);
            btCount.AddValue(rect.YMin);
            btCount.AddValue(rect.YMax);
            var bits = btCount.GetSignedBits();
            if (bits < 1) bits = 1;
            writer.WriteUnsignedBits((uint)bits, 5);
            writer.WriteSignedBits(rect.XMin, (uint)bits);
            writer.WriteSignedBits(rect.XMax, (uint)bits);
            writer.WriteSignedBits(rect.YMin, (uint)bits);
            writer.WriteSignedBits(rect.YMax, (uint)bits);
        }

        public static void WriteMatrix(this SwfStreamWriter writer, SwfMatrix matrix) {
            bool hasScale = matrix.HasScale;
            writer.WriteBit(hasScale);
            if (hasScale) {
                throw new NotImplementedException();
            }
            bool hasRotate = matrix.HasRotate;
            if (hasRotate) {
                throw new NotImplementedException();
            }
            var translateBits = new BitsCount(matrix.TranslateX, matrix.TranslateY).GetUnsignedBits();
            writer.WriteUnsignedBits(translateBits, 5);
            writer.WriteSignedBits(matrix.TranslateX, translateBits);
            writer.WriteSignedBits(matrix.TranslateY, translateBits);
        }


        public static void WriteRGB(this SwfStreamWriter writer, SwfRGB val) {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }

        public static void WriteShapeWithStyle(this SwfStreamWriter writer, ShapeWithStyle1 shapeWithStyle) {
            writer.WriteFillStyles(shapeWithStyle.FillStyles);
            writer.WriteLineStyles(shapeWithStyle.LineStyles);
            var fillStyleBits = new BitsCount(shapeWithStyle.FillStyles.Count).GetUnsignedBits();
            var lineStyleBits = new BitsCount(shapeWithStyle.LineStyles.Count).GetUnsignedBits();
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.WriteShapeRecords(shapeWithStyle.ShapeRecords, ref fillStyleBits, ref lineStyleBits);
        }

        public static void WriteFillStyles(this SwfStreamWriter writer, FillStyles1List styles) {
            for (var i = 0; i < styles.Count; i++) {
                var style = styles[i];
                switch (style.Type) {
                    case FillStyleType.ClippedBitmap:
                        writer.WriteClippedBitmapFillStyle((ClippedBitmapFillStyle)style);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown fill style type " + style.Type);
                }
            }
        }

        public static void WriteLineStyles(this SwfStreamWriter writer, LineStyles1List styles) {
            for (var i = 0; i < styles.Count; i++) {
                var style = styles[i];
                switch (style.Type) {
                    default:
                        throw new InvalidOperationException("Unknown line style type " + style.Type);
                }
            }
        }

        public static void WriteClippedBitmapFillStyle(this SwfStreamWriter writer, ClippedBitmapFillStyle style) {
            writer.WriteByte(0x41);
            writer.WriteUInt16(style.ObjectID);
            writer.WriteMatrix(style.BitmapMatrix);
        }

        public static void WriteShapeRecords(this SwfStreamWriter writer, ShapeRecords1List shapeRecords, ref uint fillStyleBits, ref uint lineStyleBits) {
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord);
            }
        }

        public static void WriteShapeRecord(this SwfStreamWriter writer, ShapeRecord shapeRecord) {
            writer.FlushBits();
            switch (shapeRecord.Type) {
                case ShapeRecordType.CurvedEdgeRecord:
                    writer.WriteCurvedEdge((CurvedEdgeShapeRecord)shapeRecord);
                    break;
                default:
                    throw new InvalidOperationException("Unknown shape record type");
            }
        }

        public static void WriteCurvedEdge(this SwfStreamWriter writer, CurvedEdgeShapeRecord record) {
            throw new NotImplementedException();
        }

        public static void WriteStyleChangeShapeRecord(this SwfStreamWriter writer, StyleChangeShapeRecord record, ref uint fillStylesBits, ref uint lineStylesBits) {
            writer.WriteBit(false);
            writer.WriteBit(false);
            bool stateFillStyle0 = record.FillStyle0.HasValue;
            bool stateFillStyle1 = record.FillStyle1.HasValue;
            bool stateLineStyle = record.LineStyle.HasValue;
            bool stateMoveTo = record.MoveDeltaX != 0 || record.MoveDeltaY != 0;
            writer.WriteBit(stateLineStyle);
            writer.WriteBit(stateFillStyle1);
            writer.WriteBit(stateFillStyle0);
            writer.WriteBit(stateMoveTo);
            if (stateMoveTo) {
                BitsCount cnt = new BitsCount(record.MoveDeltaX, record.MoveDeltaY);
                var moveBits = cnt.GetSignedBits();
                writer.WriteUnsignedBits((uint)moveBits, 5);
                writer.WriteSignedBits(record.MoveDeltaX, (uint)moveBits);
                writer.WriteSignedBits(record.MoveDeltaY, (uint)moveBits);
            }
            if (stateFillStyle0) {
                writer.WriteUnsignedBits(record.FillStyle0.Value, fillStylesBits);
            }
            if (stateFillStyle1) {
                writer.WriteUnsignedBits(record.FillStyle1.Value, fillStylesBits);
            }
            if (stateLineStyle) {
                writer.WriteUnsignedBits(record.LineStyle.Value, lineStylesBits);
            }
            //TODO: Write line styles, fill styles, line/fill bits
            throw new NotImplementedException();
        }
    }
}
