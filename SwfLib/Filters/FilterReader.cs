using SwfLib.Data;
using SwfLib.Gradients;

namespace SwfLib.Filters {
    public class FilterReader : IFilterVisitor<ISwfStreamReader, BaseFilter> {

        private readonly FilterFactory _factory = new FilterFactory();

        public BaseFilter Read(ISwfStreamReader reader) {
            var type = (FilterType)reader.ReadByte();
            var filter = _factory.Create(type);
            filter.AcceptVisitor(this, reader);
            return filter;
        }

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(DropShadowFilter filter, ISwfStreamReader reader) {
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

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(BlurFilter filter, ISwfStreamReader reader) {
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Passes = reader.ReadUnsignedBits(5);
            filter.Reserved = reader.ReadUnsignedBits(3);
            return filter;
        }

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(GlowFilter filter, ISwfStreamReader reader) {
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

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(BevelFilter filter, ISwfStreamReader reader) {
            filter.ShadowColor = reader.ReadRGBA();
            filter.HighlightColor = reader.ReadRGBA();
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Angle = reader.ReadFixed();
            filter.Distance = reader.ReadFixed();
            filter.Strength = reader.ReadFixedPoint8();
            filter.InnerShadow = reader.ReadBit();
            filter.Knockout = reader.ReadBit();
            filter.CompositeSource = reader.ReadBit();
            filter.OnTop = reader.ReadBit();
            filter.Passes = reader.ReadUnsignedBits(4);
            return filter;
        }

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(GradientGlowFilter filter, ISwfStreamReader reader) {
            var count = reader.ReadByte();
            for (var i = 0; i < count; i++) {
                var record = new GradientRecordRGBA();
                record.Color = reader.ReadRGBA();
                filter.GradientColors.Add(record);
            }
            for (var i = 0; i < count; i++) {
                filter.GradientColors[i].Ratio = reader.ReadByte();
            }
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Angle = reader.ReadFixed();
            filter.Distance = reader.ReadFixed();
            filter.Strength = reader.ReadFixedPoint8();
            filter.InnerGlow = reader.ReadBit();
            filter.Knockout = reader.ReadBit();
            filter.CompositeSource = reader.ReadBit();
            filter.OnTop = reader.ReadBit();
            filter.Passes = reader.ReadUnsignedBits(4);
            return filter;
        }

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(ConvolutionFilter filter, ISwfStreamReader reader) {
            var matrixX = reader.ReadByte();
            var matrixY = reader.ReadByte();
            filter.Divisor = reader.ReadSingle();
            filter.Bias = reader.ReadSingle();
            filter.Matrix = new double[matrixY, matrixX];
            for (var x = 0; x < matrixX; x++) {
                for (var y = 0; y < matrixY; y++) {
                    filter.Matrix[y, x] = reader.ReadSingle();
                }
            }
            filter.DefaultColor = reader.ReadRGBA();
            filter.Reserved = (byte)reader.ReadUnsignedBits(6);
            filter.Clamp = reader.ReadBit();
            filter.PreserveAlpha = reader.ReadBit();
            return filter;
        }

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(ColorMatrixFilter filter, ISwfStreamReader reader) {
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

        BaseFilter IFilterVisitor<ISwfStreamReader, BaseFilter>.Visit(GradientBevelFilter filter, ISwfStreamReader reader) {
            var count = reader.ReadByte();
            for (var i = 0; i < count; i++) {
                var record = new GradientRecordRGBA();
                record.Color = reader.ReadRGBA();
                filter.GradientColors.Add(record);
            }
            for (var i = 0; i < count; i++) {
                filter.GradientColors[i].Ratio = reader.ReadByte();
            }
            filter.BlurX = reader.ReadFixed();
            filter.BlurY = reader.ReadFixed();
            filter.Angle = reader.ReadFixed();
            filter.Distance = reader.ReadFixed();
            filter.Strength = reader.ReadFixedPoint8();
            filter.InnerGlow = reader.ReadBit();
            filter.Knockout = reader.ReadBit();
            filter.CompositeSource = reader.ReadBit();
            filter.OnTop = reader.ReadBit();
            filter.Passes = reader.ReadUnsignedBits(4);
            return filter;
        }
    }
}
