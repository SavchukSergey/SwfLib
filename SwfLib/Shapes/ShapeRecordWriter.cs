using SwfLib.Shapes.Records;
using SwfLib.Utils;

namespace SwfLib.Shapes {
    public class ShapeRecordWriter : IShapeRecordVisitor<ShapeRecordWriter.ShapeRecordWriteContext, ShapeRecordWriter.ShapeRecordWriteContext> {

        private struct ShapeRecordWriteContext {
            public uint FillStyleBits;
            public uint LineStyleBits;
            public bool AllowBigArray;
            public ISwfStreamWriter Writer;
        }

        public void WriteRGB(ISwfStreamWriter writer, IShapeRecordRGB record, bool allowBigArray, ref uint fillBitsCount, ref uint lineBitsCount) {
            Write(writer, record, allowBigArray, ref fillBitsCount, ref lineBitsCount);
        }

        public void WriteRGBA(ISwfStreamWriter writer, IShapeRecordRGBA record, bool allowBigArray, ref uint fillBitsCount, ref uint lineBitsCount) {
            Write(writer, record, allowBigArray, ref fillBitsCount, ref lineBitsCount);
        }

        public void WriteEx(ISwfStreamWriter writer, IShapeRecordEx record, bool allowBigArray, ref uint fillBitsCount, ref uint lineBitsCount) {
            Write(writer, record, allowBigArray, ref fillBitsCount, ref lineBitsCount);
        }

        private void Write(ISwfStreamWriter writer, IShapeRecord record, bool allowBigArray, ref uint fillBitsCount, ref uint lineBitsCount) {
            var ctx = new ShapeRecordWriteContext {
                FillStyleBits = fillBitsCount,
                LineStyleBits = lineBitsCount,
                AllowBigArray = allowBigArray,
                Writer = writer
            };
            ctx = record.AcceptVisitor(this, ctx);
            fillBitsCount = ctx.FillStyleBits;
            lineBitsCount = ctx.LineStyleBits;
        }

        private static void WriteStyleChangeShapeRecord(ISwfStreamWriter writer, StyleChangeShapeRecord record, ref uint fillStylesBits, ref uint lineStylesBits) {
            writer.WriteBit(false);
            var stateNewStyles = record.StateNewStyles;
            var stateFillStyle0 = record.FillStyle0.HasValue;
            var stateFillStyle1 = record.FillStyle1.HasValue;
            var stateLineStyle = record.LineStyle.HasValue;
            var stateMoveTo = record.StateMoveTo;
            writer.WriteBit(stateNewStyles);
            writer.WriteBit(stateLineStyle);
            writer.WriteBit(stateFillStyle1);
            writer.WriteBit(stateFillStyle0);
            writer.WriteBit(stateMoveTo);
            if (stateMoveTo) {
                var cnt = new SignedBitsCount(record.MoveDeltaX, record.MoveDeltaY);
                var moveBits = cnt.GetBits();
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

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(EndShapeRecord record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            writer.WriteUnsignedBits(0, 6);
            return ctx;
        }

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(StyleChangeShapeRecordRGB record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            WriteStyleChangeShapeRecord(writer, record, ref ctx.FillStyleBits, ref ctx.LineStyleBits);
            if (record.StateNewStyles) {
                writer.WriteFillStylesRGB(record.FillStyles, ctx.AllowBigArray);
                writer.WriteLineStylesRGB(record.LineStyles, ctx.AllowBigArray);
                ctx.FillStyleBits = new UnsignedBitsCount((uint) record.FillStyles.Count).GetBits();
                ctx.LineStyleBits = new UnsignedBitsCount((uint) record.LineStyles.Count).GetBits();
                if (ctx.FillStyleBits < 1) ctx.FillStyleBits = 1; //TODO: adobe?
                writer.WriteUnsignedBits(ctx.FillStyleBits, 4);
                writer.WriteUnsignedBits(ctx.LineStyleBits, 4);
            }
            return ctx;
        }

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(StyleChangeShapeRecordRGBA record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            WriteStyleChangeShapeRecord(writer, record, ref ctx.FillStyleBits, ref ctx.LineStyleBits);
            if (record.StateNewStyles) {
                writer.WriteFillStylesRGBA(record.FillStyles);
                writer.WriteLineStylesRGBA(record.LineStyles);
                ctx.FillStyleBits = new UnsignedBitsCount((uint) record.FillStyles.Count).GetBits();
                ctx.LineStyleBits = new UnsignedBitsCount((uint) record.LineStyles.Count).GetBits();
                if (ctx.FillStyleBits < 1) ctx.FillStyleBits = 1; //TODO: adobe?
                writer.WriteUnsignedBits(ctx.FillStyleBits, 4);
                writer.WriteUnsignedBits(ctx.LineStyleBits, 4);
            }
            return ctx;
        }

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(StyleChangeShapeRecordEx record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            WriteStyleChangeShapeRecord(writer, record, ref ctx.FillStyleBits, ref ctx.LineStyleBits);
            if (record.StateNewStyles) {
                writer.WriteFillStylesRGBA(record.FillStyles);
                writer.WriteLineStylesEx(record.LineStyles);
                ctx.FillStyleBits = new UnsignedBitsCount((uint) record.FillStyles.Count).GetBits();
                ctx.LineStyleBits = new UnsignedBitsCount((uint) record.LineStyles.Count).GetBits();
                if (ctx.FillStyleBits < 1) ctx.FillStyleBits = 1; //TODO: adobe?
                writer.WriteUnsignedBits(ctx.FillStyleBits, 4);
                writer.WriteUnsignedBits(ctx.LineStyleBits, 4);
            }
            return ctx;
        }

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(StraightEdgeShapeRecord record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            writer.WriteBit(true);
            writer.WriteBit(true);
            var actualBits = new SignedBitsCount(record.DeltaX, record.DeltaY).GetBits();
            if (actualBits < 2) actualBits = 2;
            writer.WriteUnsignedBits(actualBits - 2u, 4);
            bool genLineFlags = record.DeltaX != 0 && record.DeltaY != 0;
            writer.WriteBit(genLineFlags);
            bool vertFlag = record.DeltaX == 0;
            if (!genLineFlags) writer.WriteBit(vertFlag);
            if (genLineFlags || !vertFlag) writer.WriteSignedBits(record.DeltaX, actualBits);
            if (genLineFlags || vertFlag) writer.WriteSignedBits(record.DeltaY, actualBits);
            return ctx;
        }

        ShapeRecordWriteContext IShapeRecordVisitor<ShapeRecordWriteContext, ShapeRecordWriteContext>.Visit(CurvedEdgeShapeRecord record, ShapeRecordWriteContext ctx) {
            var writer = ctx.Writer;
            writer.WriteBit(true);
            writer.WriteBit(false);
            var actualBits = new SignedBitsCount(record.ControlDeltaX, record.ControlDeltaY, record.AnchorDeltaX, record.AnchorDeltaY).GetBits();
            if (actualBits < 2) actualBits = 2;
            writer.WriteUnsignedBits(actualBits - 2u, 4);
            writer.WriteSignedBits(record.ControlDeltaX, actualBits);
            writer.WriteSignedBits(record.ControlDeltaY, actualBits);
            writer.WriteSignedBits(record.AnchorDeltaX, actualBits);
            writer.WriteSignedBits(record.AnchorDeltaY, actualBits);
            return ctx;
        }
    }
}
