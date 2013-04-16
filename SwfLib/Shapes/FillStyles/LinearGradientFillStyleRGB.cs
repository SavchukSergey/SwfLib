using Code.SwfLib.Shapes.FillStyles;
using SwfLib.Data;
using SwfLib.Gradients;

namespace SwfLib.Shapes.FillStyles {
    public class LinearGradientFillStyleRGB : FillStyleRGB {

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.LinearGradient; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
