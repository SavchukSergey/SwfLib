using Code.SwfLib.Shapes.Records;
using SwfLib;

namespace Code.SwfLib.Shapes {
    public class ShapeRecordExReader : ShapeRecordReader<IShapeRecordEx, StyleChangeShapeRecordEx> {
        protected override StyleChangeShapeRecordEx CreateStyleChangeRecord() {
            return new StyleChangeShapeRecordEx();
        }

        protected override void ReadFillStyles(ISwfStreamReader reader, StyleChangeShapeRecordEx record, bool allowBigArray) {
            reader.ReadToFillStylesRGBA(record.FillStyles);
        }

        protected override void ReadLineStyles(ISwfStreamReader reader, StyleChangeShapeRecordEx record, bool allowBigArray) {
            reader.ReadToLineStylesEx(record.LineStyles);
        }

        protected override IShapeRecordEx Adapt(EndShapeRecord record) {
            return record;
        }

        protected override IShapeRecordEx Adapt(StraightEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordEx Adapt(CurvedEdgeShapeRecord record) {
            return record;
        }

        protected override IShapeRecordEx Adapt(StyleChangeShapeRecordEx record) {
            return record;
        }
    }
}
