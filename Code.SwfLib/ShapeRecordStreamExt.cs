using System;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.LineStyles;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib {
    public static class ShapeRecordStreamExt {

        public static void WriteShapeWithStyle(this SwfStreamWriter writer, ShapeWithStyle1 shapeWithStyle) {
            writer.WriteFillStyles(shapeWithStyle.FillStyles);
            writer.WriteLineStyles(shapeWithStyle.LineStyles);
            var fillStyleBits = new BitsCount(shapeWithStyle.FillStyles.Count).GetUnsignedBits();
            var lineStyleBits = new BitsCount(shapeWithStyle.LineStyles.Count).GetUnsignedBits();
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.WriteShapeRecords(shapeWithStyle.ShapeRecords, ref fillStyleBits, ref lineStyleBits);
        }

        public static void ReadToShapeWithStyle(this SwfStreamReader reader, ShapeWithStyle1 style) {
            style.FillStyles.Clear();
            reader.ReadToFillStyles(style.FillStyles);

            style.LineStyles.Clear();
            reader.ReadToLineStyles(style.LineStyles);

            var fillBitsCount = reader.ReadUnsignedBits(4);
            var lineBitsCount = reader.ReadUnsignedBits(4);

            ShapeRecord record;
            do {
                record = reader.ReadShapeRecord1(ref fillBitsCount, ref lineBitsCount);
            } while (!(record is EndShapeRecord));
        }

        public static void WriteShapeRecords(this SwfStreamWriter writer, ShapeRecords1List shapeRecords, ref uint fillStyleBits, ref uint lineStyleBits) {
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord, ref fillStyleBits, ref lineStyleBits);
            }
        }

        public static ShapeRecord ReadShapeRecord1(this SwfStreamReader reader, ref uint fillBitsCount, ref uint lineBitsCount) {
            //TODO: Read shape records
            return new EndShapeRecord();
        }


        public static void WriteShapeRecord(this SwfStreamWriter writer, ShapeRecord shapeRecord, ref uint fillStyleBits, ref uint lineStyleBits) {
            writer.FlushBits();
            switch (shapeRecord.Type) {
                case ShapeRecordType.CurvedEdgeRecord:
                    writer.WriteCurvedEdge((CurvedEdgeShapeRecord)shapeRecord);
                    break;
                case ShapeRecordType.StraightEdge:
                    writer.WriteStraightEdge((StraightEdgeShapeRecord)shapeRecord);
                    break;
                case ShapeRecordType.StyleChangeRecord:
                    writer.WriteStyleChangeShapeRecord((StyleChangeShapeRecord)shapeRecord, ref fillStyleBits, ref lineStyleBits);
                    break;
                case ShapeRecordType.EndRecord:
                    writer.WriteEndShapeRecord((EndShapeRecord)shapeRecord);
                    break;
                default:
                    throw new NotSupportedException("Unknown shape record type " + shapeRecord.Type);
            }
        }

        public static void WriteEndShapeRecord(this SwfStreamWriter writer, EndShapeRecord record) {
            writer.WriteUnsignedBits(0, 6);
        }

        public static void WriteStraightEdge(this SwfStreamWriter writer, StraightEdgeShapeRecord record) {
            writer.WriteBit(true);
            writer.WriteBit(false);
            var numBits = new BitsCount(record.DeltaX, record.DeltaY).GetUnsignedBits();
            writer.WriteUnsignedBits(numBits, 4);
            bool genLineFlags = record.DeltaX != 0 && record.DeltaY != 0;
            bool vertFlag = record.DeltaY != 0;
            writer.WriteBit(genLineFlags);
            if (!genLineFlags) writer.WriteBit(vertFlag);
            if (genLineFlags || !vertFlag) writer.WriteSignedBits(record.DeltaX, numBits);
            if (genLineFlags || vertFlag) writer.WriteSignedBits(record.DeltaY, numBits);
        }

        public static void WriteCurvedEdge(this SwfStreamWriter writer, CurvedEdgeShapeRecord record) {
            writer.WriteBit(true);
            writer.WriteBit(false);
            var actualBits =
                new BitsCount(record.ControlDeltaX, record.ControlDeltaY, record.AnchorDeltaX, record.AnchorDeltaY).
                    GetSignedBits();
            if (actualBits < 2) actualBits = 2;
            var numBits = actualBits - 2u;
            writer.WriteUnsignedBits(numBits, 4);
            writer.WriteSignedBits(record.ControlDeltaX, numBits);
            writer.WriteSignedBits(record.ControlDeltaY, numBits);
            writer.WriteSignedBits(record.AnchorDeltaX, numBits);
            writer.WriteSignedBits(record.AnchorDeltaY, numBits);
        }

        //TODO: Remove ref tokens. It's needed for StyleChange2 Records
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
                writer.WriteUnsignedBits(moveBits, 5);
                writer.WriteSignedBits(record.MoveDeltaX, moveBits);
                writer.WriteSignedBits(record.MoveDeltaY, moveBits);
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
        }

    }
}
