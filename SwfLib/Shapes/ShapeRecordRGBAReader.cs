using Code.SwfLib.Shapes.Records;
using SwfLib;

namespace Code.SwfLib.Shapes {
    public class ShapeRecordRGBAReader : ShapeRecordReader<IShapeRecordRGBA, StyleChangeShapeRecordRGBA> {

        protected override StyleChangeShapeRecordRGBA CreateStyleChangeRecord() {
            return new StyleChangeShapeRecordRGBA();
        }

        protected override void ReadFillStyles(ISwfStreamReader reader, StyleChangeShapeRecordRGBA record, bool allowBigArray) {
            reader.ReadToFillStylesRGBA(record.FillStyles);
        }

        protected override void ReadLineStyles(ISwfStreamReader reader, StyleChangeShapeRecordRGBA record, bool allowBigArray) {
            reader.ReadToLineStylesRGBA(record.LineStyles);
        }

        protected override IShapeRecordRGBA Adapt(EndShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGBA Adapt(StraightEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGBA Adapt(CurvedEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGBA Adapt(StyleChangeShapeRecordRGBA record) {
            return record;
        }
    }
}
