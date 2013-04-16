using SwfLib.Data;
using SwfLib.Gradients;

namespace SwfLib.Shapes.FillStyles {
    public class FocalGradientFillStyleRGBA : FillStyleRGBA {

        public SwfMatrix GradientMatrix;

        public FocalGradientRGBA Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.FocalGradient; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
