namespace Code.SwfLib.Filters {
    public class DropShadowFilter : BaseFilter {
        
        public override FilterType Type {
            get { return FilterType.DropShadow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
