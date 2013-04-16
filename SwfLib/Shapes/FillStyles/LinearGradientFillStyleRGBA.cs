using Code.SwfLib.Data;
using SwfLib.Data;
using SwfLib.Gradients;
using SwfLib.Shapes.FillStyles;

namespace Code.SwfLib.Shapes.FillStyles {
    public class LinearGradientFillStyleRGBA : FillStyleRGBA {

        public SwfMatrix GradientMatrix;

        public GradientRGBA Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.LinearGradient; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
