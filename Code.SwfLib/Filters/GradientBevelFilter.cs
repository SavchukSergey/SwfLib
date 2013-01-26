namespace Code.SwfLib.Filters {
    public class GradientBevelFilter : BaseFilter {

        public override FilterType Type {
            get { return FilterType.GradientBevel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
