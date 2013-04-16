using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBAReader : IFillStyleRGBAVisitor<ISwfStreamReader, FillStyleRGBA> {

        private static readonly FillStyleFactory _factory = new FillStyleFactory();

        public FillStyleRGBA Read(ISwfStreamReader reader, FillStyleType type) {
            var fillStyle = _factory.CreateRGBA(type);
            fillStyle.AcceptVisitor(this, reader);
            return fillStyle;
        }

        public FillStyleRGBA Visit(SolidFillStyleRGBA fillStyle, ISwfStreamReader reader) {
            fillStyle.Color = reader.ReadRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(LinearGradientFillStyleRGBA fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(RadialGradientFillStyleRGBA fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(FocalGradientFillStyleRGBA fillStyle, ISwfStreamReader reader) {
            fillStyle.GradientMatrix = reader.ReadMatrix();
            fillStyle.Gradient = reader.ReadFocalGradientRGBA();
            return fillStyle;
        }

        public FillStyleRGBA Visit(BitmapFillStyleRGBA fillStyle, ISwfStreamReader reader) {
            fillStyle.BitmapID = reader.ReadUInt16();
            fillStyle.BitmapMatrix = reader.ReadMatrix();
            return fillStyle;
        }
    }
}
