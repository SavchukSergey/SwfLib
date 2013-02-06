using System;

namespace Code.SwfLib.Filters {
    public class FilterReader : IFilterVisitor<SwfStreamReader, BaseFilter> {

        private readonly FilterFactory _factory = new FilterFactory();

        public BaseFilter Read(SwfStreamReader reader) {
            var type = (FilterType)reader.ReadByte();
            var filter = _factory.Create(type);
            filter.AcceptVisitor(this, reader);
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(DropShadowFilter filter, SwfStreamReader reader) {
            filter.Color = reader.ReadRGBA();
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Angle = reader.ReadFixed();
            filter.Distance = reader.ReadFixed();
            filter.Strength = reader.ReadFixedPoint8();
            filter.InnerShadow = reader.ReadBit();
            filter.Knockout = reader.ReadBit();
            filter.CompositeSource = reader.ReadBit();
            filter.Passes = reader.ReadUnsignedBits(5);
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(BlurFilter filter, SwfStreamReader reader) {
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Passes = reader.ReadUnsignedBits(5);
            filter.Reserved = reader.ReadUnsignedBits(3);
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(GlowFilter filter, SwfStreamReader reader) {
            filter.Color = reader.ReadRGBA();
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Strength = reader.ReadFixedPoint8();
            filter.InnerGlow = reader.ReadBit();
            filter.Knockout = reader.ReadBit();
            filter.CompositeSource = reader.ReadBit();
            filter.Passes = reader.ReadUnsignedBits(5);
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(BevelFilter filter, SwfStreamReader reader) {
            throw new NotImplementedException();
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(GradientGlowFilter filter, SwfStreamReader reader) {
            throw new NotImplementedException();
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(ConvolutionFilter filter, SwfStreamReader reader) {
            var matrixX = reader.ReadByte();
            var matrixY = reader.ReadByte();
            filter.Divisor = reader.ReadSingle();
            filter.Bias = reader.ReadSingle();
            filter.Matrix = new double[matrixX, matrixY];
            for (var x = 0; x < matrixX; x++) {
                for (var y = 0; y < matrixY; y++) {
                    filter.Matrix[x, y] = reader.ReadSingle();
                }
            }
            filter.DefaultColor = reader.ReadRGBA();
            filter.Reserved = (byte)reader.ReadUnsignedBits(6);
            filter.Clamp = reader.ReadBit();
            filter.PreserveAlpha = reader.ReadBit();
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(ColorMatrixFilter filter, SwfStreamReader reader) {
            filter.R0 = reader.ReadSingle();
            filter.R1 = reader.ReadSingle();
            filter.R2 = reader.ReadSingle();
            filter.R3 = reader.ReadSingle();
            filter.R4 = reader.ReadSingle();

            filter.G0 = reader.ReadSingle();
            filter.G1 = reader.ReadSingle();
            filter.G2 = reader.ReadSingle();
            filter.G3 = reader.ReadSingle();
            filter.G4 = reader.ReadSingle();

            filter.B0 = reader.ReadSingle();
            filter.B1 = reader.ReadSingle();
            filter.B2 = reader.ReadSingle();
            filter.B3 = reader.ReadSingle();
            filter.B4 = reader.ReadSingle();

            filter.A0 = reader.ReadSingle();
            filter.A1 = reader.ReadSingle();
            filter.A2 = reader.ReadSingle();
            filter.A3 = reader.ReadSingle();
            filter.A4 = reader.ReadSingle();
            return filter;
        }

        BaseFilter IFilterVisitor<SwfStreamReader, BaseFilter>.Visit(GradientBevelFilter filter, SwfStreamReader reader) {
            throw new NotImplementedException();
        }
    }
}
