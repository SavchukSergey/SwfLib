using SwfLib.Data;

namespace SwfLib.Filters {
    public class FilterWriter : IFilterVisitor<ISwfStreamWriter, object> {

        public void Write(ISwfStreamWriter writer, BaseFilter filter) {
            writer.WriteByte((byte)filter.Type);
            filter.AcceptVisitor(this, writer);
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(DropShadowFilter filter, ISwfStreamWriter writer) {
            writer.WriteRGBA(ref filter.Color);
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixed(filter.Angle);

            writer.WriteFixed(filter.Distance);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerShadow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);

            writer.WriteUnsignedBits(filter.Passes, 5);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(BlurFilter filter, ISwfStreamWriter writer) {
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);

            writer.WriteUnsignedBits(filter.Passes, 5);
            writer.WriteUnsignedBits(filter.Reserved, 3);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(GlowFilter filter, ISwfStreamWriter writer) {
            writer.WriteRGBA(filter.Color);
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerGlow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);
            writer.WriteUnsignedBits(filter.Passes, 5);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(BevelFilter filter, ISwfStreamWriter writer) {
            writer.WriteRGBA(filter.ShadowColor);
            writer.WriteRGBA(filter.HighlightColor);
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixed(filter.Angle);
            writer.WriteFixed(filter.Distance);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerShadow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);
            writer.WriteBit(filter.OnTop);
            writer.WriteUnsignedBits(filter.Passes, 4);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(GradientGlowFilter filter, ISwfStreamWriter writer) {
            writer.WriteByte((byte)filter.GradientColors.Count);
            foreach (var record in filter.GradientColors) {
                writer.WriteRGBA(record.Color);
            }
            foreach (var record in filter.GradientColors) {
                writer.WriteByte(record.Ratio);
            }
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixed(filter.Angle);

            writer.WriteFixed(filter.Distance);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerGlow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);
            writer.WriteBit(filter.OnTop);

            writer.WriteUnsignedBits(filter.Passes, 4);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(ConvolutionFilter filter, ISwfStreamWriter writer) {
            writer.WriteByte((byte)filter.MatrixX);
            writer.WriteByte((byte)filter.MatrixY);

            writer.WriteSingle((float)filter.Divisor);
            writer.WriteSingle((float)filter.Bias);

            for (var x = 0; x < filter.MatrixX; x++) {
                for (var y = 0; y < filter.MatrixY; y++) {
                    writer.WriteSingle((float)filter.Matrix[y, x]);
                }
            }

            writer.WriteRGBA(filter.DefaultColor);
            writer.WriteUnsignedBits(filter.Reserved, 6);
            writer.WriteBit(filter.Clamp);
            writer.WriteBit(filter.PreserveAlpha);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(ColorMatrixFilter filter, ISwfStreamWriter writer) {
            writer.WriteSingle((float)filter.R0);
            writer.WriteSingle((float)filter.R1);
            writer.WriteSingle((float)filter.R2);
            writer.WriteSingle((float)filter.R3);
            writer.WriteSingle((float)filter.R4);

            writer.WriteSingle((float)filter.G0);
            writer.WriteSingle((float)filter.G1);
            writer.WriteSingle((float)filter.G2);
            writer.WriteSingle((float)filter.G3);
            writer.WriteSingle((float)filter.G4);

            writer.WriteSingle((float)filter.B0);
            writer.WriteSingle((float)filter.B1);
            writer.WriteSingle((float)filter.B2);
            writer.WriteSingle((float)filter.B3);
            writer.WriteSingle((float)filter.B4);

            writer.WriteSingle((float)filter.A0);
            writer.WriteSingle((float)filter.A1);
            writer.WriteSingle((float)filter.A2);
            writer.WriteSingle((float)filter.A3);
            writer.WriteSingle((float)filter.A4);
            return null;
        }

        object IFilterVisitor<ISwfStreamWriter, object>.Visit(GradientBevelFilter filter, ISwfStreamWriter writer) {
            writer.WriteByte((byte)filter.GradientColors.Count);
            foreach (var record in filter.GradientColors) {
                writer.WriteRGBA(record.Color);
            }
            foreach (var record in filter.GradientColors) {
                writer.WriteByte(record.Ratio);
            }
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixed(filter.Angle);

            writer.WriteFixed(filter.Distance);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerGlow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);
            writer.WriteBit(filter.OnTop);

            writer.WriteUnsignedBits(filter.Passes, 4);
            return null;
        }
    }
}
