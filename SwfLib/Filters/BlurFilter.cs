namespace SwfLib.Filters {
    public class BlurFilter : BaseFilter {

        public double BlurX;

        public double BlurY;

        public uint Passes;

        public uint Reserved;

        public override FilterType Type {
            get { return FilterType.Blur; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
