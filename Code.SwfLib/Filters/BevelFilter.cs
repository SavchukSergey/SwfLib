namespace Code.SwfLib.Filters {
    public class BevelFilter : BaseFilter {
        
        public override FilterType Type {
            get { return FilterType.Bevel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
