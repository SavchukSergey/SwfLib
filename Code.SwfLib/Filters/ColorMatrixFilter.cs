namespace Code.SwfLib.Filters {
    public class ColorMatrixFilter : BaseFilter {

        public override FilterType Type {
            get { return FilterType.ColorMatrix; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
