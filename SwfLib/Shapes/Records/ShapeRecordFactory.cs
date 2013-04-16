using System;

namespace Code.SwfLib.Shapes.Records {
    public class ShapeRecordFactory {

        public IShapeRecordRGB CreateRGB(ShapeRecordType recordType) {
            switch (recordType) {
                case ShapeRecordType.EndRecord:
                    return new EndShapeRecord();
                case ShapeRecordType.StyleChangeRecord:
                    return new StyleChangeShapeRecordRGB();
                case ShapeRecordType.StraightEdge:
                    return new StraightEdgeShapeRecord();
                case ShapeRecordType.CurvedEdgeRecord:
                    return new CurvedEdgeShapeRecord();
                default:
                    throw new NotSupportedException();
            }
        }

        public IShapeRecordRGBA CreateRGBA(ShapeRecordType recordType) {
            switch (recordType) {
                case ShapeRecordType.EndRecord:
                    return new EndShapeRecord();
                case ShapeRecordType.StyleChangeRecord:
                    return new StyleChangeShapeRecordRGBA();
                case ShapeRecordType.StraightEdge:
                    return new StraightEdgeShapeRecord();
                case ShapeRecordType.CurvedEdgeRecord:
                    return new CurvedEdgeShapeRecord();
                default:
                    throw new NotSupportedException();
            }
        }

        public IShapeRecordEx CreateEx(ShapeRecordType recordType) {
            switch (recordType) {
                case ShapeRecordType.EndRecord:
                    return new EndShapeRecord();
                case ShapeRecordType.StyleChangeRecord:
                    return new StyleChangeShapeRecordEx();
                case ShapeRecordType.StraightEdge:
                    return new StraightEdgeShapeRecord();
                case ShapeRecordType.CurvedEdgeRecord:
                    return new CurvedEdgeShapeRecord();
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
