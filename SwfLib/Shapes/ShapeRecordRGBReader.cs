using Code.SwfLib.Shapes.Records;
using SwfLib;

namespace Code.SwfLib.Shapes {
    public class ShapeRecordRGBReader : ShapeRecordReader<IShapeRecordRGB, StyleChangeShapeRecordRGB> {

        protected override StyleChangeShapeRecordRGB CreateStyleChangeRecord() {
            return new StyleChangeShapeRecordRGB();
        }

        protected override void ReadFillStyles(ISwfStreamReader reader, StyleChangeShapeRecordRGB record, bool allowBigArray) {
            reader.ReadToFillStylesRGB(record.FillStyles, allowBigArray);
        }

        protected override void ReadLineStyles(ISwfStreamReader reader, StyleChangeShapeRecordRGB record, bool allowBigArray) {
            reader.ReadToLineStylesRGB(record.LineStyles, allowBigArray);
        }

        protected override IShapeRecordRGB Adapt(EndShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGB Adapt(StraightEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGB Adapt(CurvedEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordRGB Adapt(StyleChangeShapeRecordRGB record) {
            return record;
        }
    }
}
