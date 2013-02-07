using System;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBReader : IFillStyleRGBVisitor<SwfStreamReader, FillStyleRGB> {

        private static readonly FillStyleFactory _factory = new FillStyleFactory();

        public FillStyleRGB Read(SwfStreamReader reader, FillStyleType type) {
            var fillStyle = _factory.CreateRGB(type);
            fillStyle.AcceptVisitor(this, reader);
            return fillStyle;
        }

        public FillStyleRGB Visit(SolidFillStyleRGB fillStyle, SwfStreamReader reader) {
            fillStyle.Color = reader.ReadRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(LinearGradientFillStyleRGB fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(RadialGradientFillStyleRGB fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(FocalGradientFillStyleRGB fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadFocalGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(BitmapFillStyleRGB fillStyle, SwfStreamReader reader) {
            fillStyle.BitmapID = reader.ReadUInt16();
            fillStyle.BitmapMatrix = reader.ReadMatrix();
            return fillStyle;
        }
    }
}
