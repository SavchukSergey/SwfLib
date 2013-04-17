using SwfLib.Data;

namespace SwfLib.Filters {
    /// <summary>
    /// Represents Glow filter.
    /// </summary>
    public class GlowFilter : BaseFilter {

        /// <summary>
        /// Gets or sets color of filter.
        /// </summary>
        public SwfRGBA Color { get; set; }

        /// <summary>
        /// Gets or sets the blur X.
        /// </summary>
        public double BlurX { get; set; }

        /// <summary>
        /// Gets or sets the blur Y.
        /// </summary>
        public double BlurY { get; set; }

        /// <summary>
        /// Gets or sets strength of the filter.
        /// </summary>
        public double Strength { get; set; }

        public bool InnerGlow;

        public bool Knockout;

        public bool CompositeSource;

        /// <summary>
        /// Gets or sets count of passes to be applied.
        /// </summary>
        public uint Passes { get; set; }

        public override FilterType Type {
            get { return FilterType.Glow; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
