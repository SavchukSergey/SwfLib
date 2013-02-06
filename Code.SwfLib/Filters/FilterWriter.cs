using System;

namespace Code.SwfLib.Filters {
    public class FilterWriter : IFilterVisitor<SwfStreamWriter, object> {

        public void Write(SwfStreamWriter writer, BaseFilter filter) {
            writer.WriteByte((byte)filter.Type);
            filter.AcceptVisitor(this, writer);
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(DropShadowFilter filter, SwfStreamWriter writer) {
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

        object IFilterVisitor<SwfStreamWriter, object>.Visit(BlurFilter filter, SwfStreamWriter writer) {
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);

            writer.WriteUnsignedBits(filter.Passes, 5);
            writer.WriteUnsignedBits(filter.Reserved, 3);
            return null;
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(GlowFilter filter, SwfStreamWriter writer) {
            writer.WriteRGBA(ref filter.Color);
            writer.WriteFixed(filter.BlurX);
            writer.WriteFixed(filter.BlurY);
            writer.WriteFixedPoint8(filter.Strength);
            writer.WriteBit(filter.InnerGlow);
            writer.WriteBit(filter.Knockout);
            writer.WriteBit(filter.CompositeSource);
            writer.WriteUnsignedBits(filter.Passes, 5);
            return null;
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(BevelFilter filter, SwfStreamWriter writer) {
            throw new NotImplementedException();
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(GradientGlowFilter filter, SwfStreamWriter writer) {
            throw new NotImplementedException();
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(ConvolutionFilter filter, SwfStreamWriter writer) {
            throw new NotImplementedException();
        }

        object IFilterVisitor<SwfStreamWriter, object>.Visit(ColorMatrixFilter filter, SwfStreamWriter writer) {
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

        object IFilterVisitor<SwfStreamWriter, object>.Visit(GradientBevelFilter filter, SwfStreamWriter writer) {
            throw new NotImplementedException();
        }
    }
}
