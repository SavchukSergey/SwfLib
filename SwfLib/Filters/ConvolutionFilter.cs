using SwfLib.Data;

namespace SwfLib.Filters {
    public class ConvolutionFilter : BaseFilter {

        /// <summary>
        /// Gets or sets filter dicisor.
        /// </summary>
        public double Divisor { get; set; }

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
