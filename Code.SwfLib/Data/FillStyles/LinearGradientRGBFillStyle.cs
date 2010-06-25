using Code.SwfLib.Data.Gradients;

namespace Code.SwfLib.Data.FillStyles {
    public class LinearGradientRGBFillStyle : FillStyle {

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public override FillStyleType Type {
            get { return FillStyleType.LinearGradient; }
        }

    }
}