namespace Code.SwfLib.Data.FillStyles {
    public class LinearGradientFillStyle : FillStyle {

        public SwfMatrix GradientMatrix;

        public override FillStyleType Type {
            get { return FillStyleType.LinearGradient; }
        }

    }
}