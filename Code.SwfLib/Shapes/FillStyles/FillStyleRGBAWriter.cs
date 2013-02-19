using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBAWriter : IFillStyleRGBAVisitor<SwfStreamWriter, object> {

        public void Write(SwfStreamWriter writer, FillStyleRGBA fillStyle) {
            writer.WriteByte((byte)fillStyle.Type);
            fillStyle.AcceptVisitor(this, writer);
        }

        object IFillStyleRGBAVisitor<SwfStreamWriter, object>.Visit(SolidFillStyleRGBA fillStyle, SwfStreamWriter writer) {
            writer.WriteRGBA(fillStyle.Color);
            return null;
        }

        object IFillStyleRGBAVisitor<SwfStreamWriter, object>.Visit(LinearGradientFillStyleRGBA fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<SwfStreamWriter, object>.Visit(RadialGradientFillStyleRGBA fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<SwfStreamWriter, object>.Visit(FocalGradientFillStyleRGBA fillStyle, SwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteFocalGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<SwfStreamWriter, object>.Visit(BitmapFillStyleRGBA fillStyle, SwfStreamWriter writer) {
            writer.WriteUInt16(fillStyle.BitmapID);
            writer.WriteMatrix(ref fillStyle.BitmapMatrix);
            return null;
        }
    }
}
