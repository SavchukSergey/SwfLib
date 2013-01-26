namespace Code.SwfLib.Filters {
    public class GradientGlowFilter : BaseFilter {
        
        public override FilterType Type {
            get { return FilterType.GradientGlow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
