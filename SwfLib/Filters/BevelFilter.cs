using SwfLib.Data;

namespace SwfLib.Filters {
    public class BevelFilter : BaseFilter {

        /// <summary>
        /// Gets ot sets shadow color.
        /// </summary>
        public SwfRGBA ShadowColor { get; set; }

        /// <summary>
        /// Gets or sets highlight color.
        /// </summary>
        public SwfRGBA HighlightColor { get; set; }

        public double BlurX { get; set; }

        public double BlurY { get; set; }

        public double Angle { get; set; }

        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets filter strength.
        /// </summary>
        public double Strength { get; set; }

        public bool InnerShadow { get; set; }

        public bool Knockout { get; set; }

        public bool CompositeSource { get; set; }

        public bool OnTop { get; set; }

        public uint Passes { get; set; }

        /// <summary>
        /// Gets type of filter.
        /// </summary>
        public override FilterType Type {
            get { return FilterType.Bevel; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
