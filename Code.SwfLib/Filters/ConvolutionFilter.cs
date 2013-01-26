namespace Code.SwfLib.Filters {
    public class ConvolutionFilter : BaseFilter {

        public override FilterType Type {
            get { return FilterType.Convolution; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
