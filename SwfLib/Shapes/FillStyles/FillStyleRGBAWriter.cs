using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using SwfLib.Data;
using SwfLib.Shapes.FillStyles;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBAWriter : IFillStyleRGBAVisitor<ISwfStreamWriter, object> {

        public void Write(ISwfStreamWriter writer, FillStyleRGBA fillStyle) {
            writer.WriteByte((byte)fillStyle.Type);
            fillStyle.AcceptVisitor(this, writer);
        }

        object IFillStyleRGBAVisitor<ISwfStreamWriter, object>.Visit(SolidFillStyleRGBA fillStyle, ISwfStreamWriter writer) {
            writer.WriteRGBA(fillStyle.Color);
            return null;
        }

        object IFillStyleRGBAVisitor<ISwfStreamWriter, object>.Visit(LinearGradientFillStyleRGBA fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<ISwfStreamWriter, object>.Visit(RadialGradientFillStyleRGBA fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<ISwfStreamWriter, object>.Visit(FocalGradientFillStyleRGBA fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteFocalGradientRGBA(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBAVisitor<ISwfStreamWriter, object>.Visit(BitmapFillStyleRGBA fillStyle, ISwfStreamWriter writer) {
            writer.WriteUInt16(fillStyle.BitmapID);
            writer.WriteMatrix(ref fillStyle.BitmapMatrix);
            return null;
        }
    }
}
