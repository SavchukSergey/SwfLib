using System.Collections.Generic;
using Code.SwfLib.Shapes;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib {
    public static class ShapeRecordStreamExt {

        private static readonly ShapeRecordWriter _shapeRecordWriter = new ShapeRecordWriter();

        public static void WriteShapeRecordsRGB(this ISwfStreamWriter writer, IList<IShapeRecordRGB> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            foreach (var shapeRecord in shapeRecords) {
                _shapeRecordWriter.WriteRGB(writer, shapeRecord, false, ref fillStyleBits, ref lineStyleBits);
            }

        }

        public static void WriteShapeRecordsRGBA(this ISwfStreamWriter writer, IList<IShapeRecordRGBA> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            foreach (var shapeRecord in shapeRecords) {
                _shapeRecordWriter.WriteRGBA(writer, shapeRecord, true, ref fillStyleBits, ref lineStyleBits);
            }

        }

        public static void WriteShapeRecordsEx(this ISwfStreamWriter writer, IList<IShapeRecordEx> shapeRecords, uint fillStyleBits, uint lineStyleBits) {
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.FlushBits();
            foreach (var shapeRecord in shapeRecords) {
                _shapeRecordWriter.WriteEx(writer, shapeRecord, true, ref fillStyleBits, ref lineStyleBits);
            }

        }

        private static ShapeRecordRGBReader _shapeRecordRGBReader = new ShapeRecordRGBReader();
        private static ShapeRecordRGBAReader _shapeRecordRGBAReader = new ShapeRecordRGBAReader();
        private static ShapeRecordExReader _shapeRecorExReader = new ShapeRecordExReader();

        public static void ReadToShapeRecordsRGB(this ISwfStreamReader reader, IList<IShapeRecordRGB> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordRGB record;
            do {
                record = _shapeRecordRGBReader.Read(reader, true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }

        public static void ReadToShapeRecordsRGBA(this ISwfStreamReader reader, IList<IShapeRecordRGBA> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordRGBA record;
            do {
                record = _shapeRecordRGBAReader.Read(reader, true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }

        public static void ReadToShapeRecordsEx(this ISwfStreamReader reader, IList<IShapeRecordEx> shapeRecords) {
            var fillStyleBits = reader.ReadUnsignedBits(4);
            var lineStyleBits = reader.ReadUnsignedBits(4);
            reader.AlignToByte();
            IShapeRecordEx record;
            do {
                record = _shapeRecorExReader.Read(reader, true, ref fillStyleBits, ref lineStyleBits);
                shapeRecords.Add(record);
            } while (!(record is EndShapeRecord));
        }



    }
}
