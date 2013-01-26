namespace Code.SwfLib.Filters {
    public class GlowFilter : BaseFilter {

        public override FilterType Type {
            get { return FilterType.Glow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
