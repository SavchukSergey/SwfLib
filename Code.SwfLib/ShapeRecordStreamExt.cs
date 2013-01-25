using System;
using System.Collections.Generic;
using Code.SwfLib.Shapes;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib {
    public static class ShapeRecordStreamExt {

        public static void WriteShapeRecordsRGB(this SwfStreamWriter writer, IList<IShapeRecordRGB> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord, ref fillStyleBits, ref lineStyleBits);
            }

        }

        public static void WriteShapeRecordsRGBA(this SwfStreamWriter writer, IList<IShapeRecordRGBA> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord, ref fillStyleBits, ref lineStyleBits);
            }

        }

        public static void WriteShapeRecordsEx(this SwfStreamWriter writer, IList<IShapeRecordEx> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            for (var i = 0; i < shapeRecords.Count; i++) {
                var shapeRecord = shapeRecords[i];
                writer.WriteShapeRecord(shapeRecord, ref fillStyleBits, ref lineStyleBits);
            }

        }

        private static ShapeRecordRGBReader _shapeRecordRGBReader = new ShapeRecordRGBReader();
        private static ShapeRecordRGBAReader _shapeRecordRGBAReader = new ShapeRecordRGBAReader();
        private static ShapeRecordExReader _shapeRecorExReader = new ShapeRecordExReader();

        public static void ReadToShapeRecordsRGB(this SwfStreamReader reader, IList<IShapeRecordRGB> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordRGB record;
            do {
                record = _shapeRecordRGBReader.Read(reader, true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }

        public static void ReadToShapeRecordsRGBA(this SwfStreamReader reader, IList<IShapeRecordRGBA> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordRGBA record;
            do {
                record = _shapeRecordRGBAReader.Read(reader, true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }

        public static void ReadToShapeRecordsEx(this SwfStreamReader reader, IList<IShapeRecordEx> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordEx record;
            do {
                record = _shapeRecorExReader.Read(reader , true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }


        public static void WriteShapeRecord(this SwfStreamWriter writer, IShapeRecord shapeRecord, ref uint fillStyleBits, ref uint lineStyleBits) {
            //They are not actually byte aligned as Adobe promises..
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
