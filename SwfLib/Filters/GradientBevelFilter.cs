using System.Collections.Generic;
using SwfLib.Gradients;

namespace SwfLib.Filters {
    public class GradientBevelFilter : BaseFilter {

        public readonly IList<GradientRecordRGBA> GradientColors = new List<GradientRecordRGBA>();

        public double BlurX;

        public double BlurY;

        public double Angle;

        public double Distance;

        public double Strength;

        public bool InnerGlow;

        public bool Knockout;

        public bool CompositeSource;

        public bool OnTop;

        public uint Passes;

        public override FilterType Type {
            get { return FilterType.GradientBevel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
