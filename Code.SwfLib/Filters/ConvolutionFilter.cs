using Code.SwfLib.Data;

namespace Code.SwfLib.Filters {
    public class ConvolutionFilter : BaseFilter {

        public double Divisor;

        public double Bias;

        public double[,] Matrix;

        public SwfRGBA DefaultColor;

        public byte Reserved;

        public bool Clamp;

        public bool PreserveAlpha;

        public int MatrixX {
            get {
                return Matrix != null ? Matrix.GetLength(1) : 0;
            }
        }

        public int MatrixY {
            get {
                return Matrix != null ? Matrix.GetLength(0) : 0;
            }
        }

        public override FilterType Type {
            get { return FilterType.Convolution; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
