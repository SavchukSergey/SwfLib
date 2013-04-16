using SwfLib.Data;

namespace SwfLib.Filters {
    public class GlowFilter : BaseFilter {

        public SwfRGBA Color;

        public double BlurX;

        public double BlurY;

        public double Strength;

        public bool InnerGlow;

        public bool Knockout;

        public bool CompositeSource;

        public uint Passes;

        public override FilterType Type {
            get { return FilterType.Glow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
