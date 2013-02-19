using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FillStyleRGBWriter : IFillStyleRGBVisitor<ISwfStreamWriter, object> {

        public void Write(ISwfStreamWriter writer, FillStyleRGB fillStyle) {
            writer.WriteByte((byte)fillStyle.Type);
            fillStyle.AcceptVisitor(this, writer);
        }

        object IFillStyleRGBVisitor<ISwfStreamWriter, object>.Visit(SolidFillStyleRGB fillStyle, ISwfStreamWriter writer) {
            writer.WriteRGB(fillStyle.Color);
            return null;
        }

        object IFillStyleRGBVisitor<ISwfStreamWriter, object>.Visit(LinearGradientFillStyleRGB fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<ISwfStreamWriter, object>.Visit(RadialGradientFillStyleRGB fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<ISwfStreamWriter, object>.Visit(FocalGradientFillStyleRGB fillStyle, ISwfStreamWriter writer) {
            writer.WriteMatrix(ref fillStyle.GradientMatrix);
            writer.WriteFocalGradientRGB(fillStyle.Gradient);
            return null;
        }

        object IFillStyleRGBVisitor<ISwfStreamWriter, object>.Visit(BitmapFillStyleRGB fillStyle, ISwfStreamWriter writer) {
            writer.WriteUInt16(fillStyle.BitmapID);
            writer.WriteMatrix(ref fillStyle.BitmapMatrix);
            return null;
        }
    }
}
