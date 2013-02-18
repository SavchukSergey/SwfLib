using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBReader : IFillStyleRGBVisitor<ISwfStreamReader, FillStyleRGB> {

        private static readonly FillStyleFactory _factory = new FillStyleFactory();

        public FillStyleRGB Read(ISwfStreamReader reader, FillStyleType type) {
            var fillStyle = _factory.CreateRGB(type);
            fillStyle.AcceptVisitor(this, reader);
            return fillStyle;
        }

        public FillStyleRGB Visit(SolidFillStyleRGB fillStyle, ISwfStreamReader reader) {
            fillStyle.Color = reader.ReadRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(LinearGradientFillStyleRGB fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(RadialGradientFillStyleRGB fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(FocalGradientFillStyleRGB fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadFocalGradientRGB();
            return fillStyle;
        }

        public FillStyleRGB Visit(BitmapFillStyleRGB fillStyle, ISwfStreamReader reader) {
            fillStyle.BitmapID = reader.ReadUInt16();
            fillStyle.BitmapMatrix = reader.ReadMatrix();
            return fillStyle;
        }
    }
}
