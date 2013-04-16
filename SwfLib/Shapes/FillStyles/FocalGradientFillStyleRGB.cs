using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public class FocalGradientFillStyleRGB : FillStyleRGB {

        public SwfMatrix GradientMatrix;

        public FocalGradientRGB Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.FocalGradient; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
