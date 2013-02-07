using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBAReader : IFillStyleRGBAVisitor<SwfStreamReader, FillStyleRGBA> {

        private static readonly FillStyleFactory _factory = new FillStyleFactory();

        public FillStyleRGBA Read(SwfStreamReader reader, FillStyleType type) {
            var fillStyle = _factory.CreateRGBA(type);
            fillStyle.AcceptVisitor(this, reader);
            return fillStyle;
        }

        public FillStyleRGBA Visit(SolidFillStyleRGBA fillStyle, SwfStreamReader reader) {
            fillStyle.Color = reader.ReadRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(LinearGradientFillStyleRGBA fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(RadialGradientFillStyleRGBA fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(FocalGradientFillStyleRGBA fillStyle, SwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadFocalGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(BitmapFillStyleRGBA fillStyle, SwfStreamReader reader) {
            fillStyle.BitmapID = reader.ReadUInt16();
            fillStyle.BitmapMatrix = reader.ReadMatrix();
            return fillStyle;
        }
    }
}
