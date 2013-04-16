using SwfLib.Data;

namespace SwfLib.Filters {
    public class DropShadowFilter : BaseFilter {

        public SwfRGBA Color;

        public double BlurX;

        public double BlurY;

        public double Angle;

        public double Distance;

        public double Strength;

        public bool InnerShadow;

        public bool Knockout;

        public bool CompositeSource;

        public uint Passes;
        
        public override FilterType Type {
            get { return FilterType.DropShadow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
