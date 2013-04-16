using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.Shapes {
    public abstract class ShapeRecordReader<T, TStyleChange>
        where T : IShapeRecord
        where TStyleChange : StyleChangeShapeRecord {

        public T Read(ISwfStreamReader reader, bool allowBigArray, ref uint fillBitsCount, ref uint lineBitsCount) {
            var isEdge = reader.ReadBit();
            if (!isEdge) {
                bool stateNewStyles = reader.ReadBit();
                bool stateLineStyle = reader.ReadBit();
                bool stateFillStyle1 = reader.ReadBit();
                bool stateFillStyle0 = reader.ReadBit();
                bool stateMoveTo = reader.ReadBit();
                if (stateNewStyles || stateLineStyle || stateFillStyle1 || stateFillStyle0 || stateMoveTo) {
                    var styleChange = CreateStyleChangeRecord();
                    styleChange.StateNewStyles = stateNewStyles;
                    styleChange.StateMoveTo = stateMoveTo;
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
                    if (stateNewStyles) {
                        ReadFillStyles(reader, styleChange, allowBigArray);
                        ReadLineStyles(reader, styleChange, allowBigArray);

                        fillBitsCount = reader.ReadUnsignedBits(4);
                        lineBitsCount = reader.ReadUnsignedBits(4);
                    }
                    return Adapt(styleChange);
                } else {
                    return Adapt(new EndShapeRecord());
                }
            }
            var straight = reader.ReadBit();
            return straight ? Adapt(ReadStraigtEdgeShapeRecord(reader)) : Adapt(ReadCurvedEdgeShapeRecord(reader));
        }

        private StraightEdgeShapeRecord ReadStraigtEdgeShapeRecord(ISwfStreamReader reader) {
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
        }

        private CurvedEdgeShapeRecord ReadCurvedEdgeShapeRecord(ISwfStreamReader reader) {
            var record = new CurvedEdgeShapeRecord();
            var numBits = reader.ReadUnsignedBits(4) + 2;
            record.ControlDeltaX = reader.ReadSignedBits(numBits);
            record.ControlDeltaY = reader.ReadSignedBits(numBits);
            record.AnchorDeltaX = reader.ReadSignedBits(numBits);
            record.AnchorDeltaY = reader.ReadSignedBits(numBits);
            return record;
        }

        protected abstract TStyleChange CreateStyleChangeRecord();
        protected abstract void ReadFillStyles(ISwfStreamReader reader, TStyleChange record, bool allowBigArray);
        protected abstract void ReadLineStyles(ISwfStreamReader reader, TStyleChange record, bool allowBigArray);

        protected abstract T Adapt(EndShapeRecord record);
        protected abstract T Adapt(StraightEdgeShapeRecord record);
        protected abstract T Adapt(CurvedEdgeShapeRecord record);
        protected abstract T Adapt(TStyleChange record);

    }
}
