namespace Code.SwfLib.Filters {
    public class BlurFilter : BaseFilter {

        public override FilterType Type {
            get { return FilterType.Blur; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
