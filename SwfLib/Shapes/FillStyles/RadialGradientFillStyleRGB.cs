using Code.SwfLib.Data;
using SwfLib.Data;
using SwfLib.Gradients;
using SwfLib.Shapes.FillStyles;

namespace Code.SwfLib.Shapes.FillStyles {
    public class RadialGradientFillStyleRGB : FillStyleRGB {

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.RadialGradient; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
