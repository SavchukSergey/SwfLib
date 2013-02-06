using Code.SwfLib.Data;

namespace Code.SwfLib.Filters {
    public class BevelFilter : BaseFilter {

        public SwfRGBA ShadowColor;

        public SwfRGBA HighlightColor;

        public double BlurX;

        public double BlurY;

        public double Angle;

        public double Distance;

        public double Strength;

        public bool InnerShadow;

        public bool Knockout;

        public bool CompositeSource;

        public bool OnTop;

        public uint Passes;

        public override FilterType Type {
            get { return FilterType.Bevel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
