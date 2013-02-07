using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBWriter : IFillStyleRGBVisitor<SwfStreamWriter, object> {

        public void Write(SwfStreamWriter writer, FillStyleRGB fillStyle) {
            writer.WriteByte((byte)fillStyle.Type);
            fillStyle.AcceptVisitor(this, writer);
        }

        object IFillStyleRGBVisitor<SwfStreamWriter, object>.Visit(SolidFillStyleRGB fillStyle, SwfStreamWriter writer) {
            writer.WriteRGB(fillStyle.Color);
            return null;
        }

        object IFillStyleRGBVisitor<SwfStreamWriter, object>.Visit(LinearGradientFillStyleRGB fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<SwfStreamWriter, object>.Visit(RadialGradientFillStyleRGB fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<SwfStreamWriter, object>.Visit(FocalGradientFillStyleRGB fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteFocalGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<SwfStreamWriter, object>.Visit(BitmapFillStyleRGB fillStyle, SwfStreamWriter writer) {
            writer.WriteUInt16(fillStyle.BitmapID);
            writer.WriteMatrix(ref fillStyle.BitmapMatrix);
            return null;
        }
    }
}
