using System;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib {
    public static class ShapeRecordStreamExt {

        public static void WriteShapeWithStyle(this SwfStreamWriter writer, ShapeWithStyle1 shapeWithStyle) {
            writer.WriteFillStyles1(shapeWithStyle.FillStyles);
            writer.WriteLineStyles1(shapeWithStyle.LineStyles);
            var fillStyleBits = new BitsCount(shapeWithStyle.FillStyles.Count).GetUnsignedBits();
            var lineStyleBits = new BitsCount(shapeWithStyle.LineStyles.Count).GetUnsignedBits();
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.WriteShapeRecords1(shapeWithStyle.ShapeRecords, ref fillStyleBits, ref lineStyleBits);
        }

        public static void ReadToShapeWithStyle(this SwfStreamReader reader, ShapeWithStyle1 style) {
            style.FillStyles.Clear();
            reader.ReadToFillStyles1(style.FillStyles);

            style.LineStyles.Clear();
            reader.ReadToLineStyles1(style.LineStyles);

            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.ReadToShapeRecords1(style.ShapeRecords, ref fillStyleBits, ref lineStyleBits);
        }

        public static void WriteShapeRecords1(this SwfStreamWriter writer, ShapeRecords1List shapeRecords, ref uint fillStyleBits, ref uint lineStyleBits) {
            writer.FlushBits();
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord, ref fillStyleBits, ref lineStyleBits);
            }
        }

        public static void ReadToShapeRecords1(this SwfStreamReader reader, ShapeRecords1List shapeRecords, ref uint fillStyleBits, ref uint lineStyleBits) {
            reader.AlignToByte();
            ShapeRecord record;
            do {
                record = reader.ReadShapeRecord1(ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }


        public static ShapeRecord ReadShapeRecord1(this SwfStreamReader reader, ref uint fillBitsCount, ref uint lineBitsCount) {
            var isEdge = reader.ReadBit();
            if (!isEdge) {
                bool reservedFlag = reader.ReadBit();
                bool stateLineStyle = reader.ReadBit();
                bool stateFillStyle1 = reader.ReadBit();
                bool stateFillStyle0 = reader.ReadBit();
                bool stateMoveTo = reader.ReadBit();
                if (reservedFlag || stateLineStyle || stateFillStyle1 || stateFillStyle0 || stateMoveTo) {
                    var styleChange = new StyleChangeShapeRecord();
                    if (stateMoveTo) {
                        var moveBits = reader.ReadUnsignedBits(5);
                        styleChange.MoveDeltaX = reader.ReadSignedBits(moveBits);
                        styleChange.MoveDeltaY = reader.ReadSignedBits(moveBits);
                    }
                    if (stateFillStyle0) {
                        styleChange.FillStyle0 = reader.ReadUnsignedBits(fillBitsCount);
                    }
                    if (stateFillStyle1) {
                        styleChange.FillStyle1 = reader.ReadUnsignedBits(fillBitsCount);
                    }
                    if (stateLineStyle) {
                        styleChange.LineStyle = reader.ReadUnsignedBits(lineBitsCount);
                    }
                    return styleChange;
                } else {
                    return new EndShapeRecord();
                }
            }
            bool straight = reader.ReadBit();
            if (straight) {
                var record = new StraightEdgeShapeRecord();
                var numBits = reader.ReadUnsignedBits(4) + 2;
                var generalLineFlag = reader.ReadBit();
                bool vertLineFlag = false;
                if (!generalLineFlag) {
                    vertLineFlag = reader.ReadBit();
                }
                if (generalLineFlag || !vertLineFlag) {
                    record.DeltaX = reader.ReadSignedBits(numBits);
                }
                if (generalLineFlag || vertLineFlag) {
                    record.DeltaY = reader.ReadSignedBits(numBits);
                }
                return record;
            } else {
                var record = new CurvedEdgeShapeRecord();
                var numBits = reader.ReadUnsignedBits(4) + 2;
                record.ControlDeltaX = reader.ReadSignedBits(numBits);
                record.ControlDeltaY = reader.ReadSignedBits(numBits);
                record.AnchorDeltaX = reader.ReadSignedBits(numBits);
                record.AnchorDeltaY = reader.ReadSignedBits(numBits);
                return record;
            }
        }


        public static void WriteShapeRecord(this SwfStreamWriter writer, ShapeRecord shapeRecord, ref uint fillStyleBits, ref uint lineStyleBits) {
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
            writer.WriteBit(true);
            var actualBits = new BitsCount(record.DeltaX, record.DeltaY).GetSignedBits();
            if (actualBits < 2) actualBits = 2;
            var numBits = actualBits - 2u;
            writer.WriteUnsignedBits(numBits, 4);
            bool genLineFlags = record.DeltaX != 0 && record.DeltaY != 0;
            bool vertFlag = record.DeltaY != 0;
            writer.WriteBit(genLineFlags);
            if (!genLineFlags) writer.WriteBit(vertFlag);
            if (genLineFlags || !vertFlag) writer.WriteSignedBits(record.DeltaX, actualBits);
            if (genLineFlags || vertFlag) writer.WriteSignedBits(record.DeltaY, actualBits);
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
            writer.WriteSignedBits(record.ControlDeltaX, actualBits);
            writer.WriteSignedBits(record.ControlDeltaY, actualBits);
            writer.WriteSignedBits(record.AnchorDeltaX, actualBits);
            writer.WriteSignedBits(record.AnchorDeltaY, actualBits);
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
