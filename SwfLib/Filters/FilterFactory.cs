using System;
using SwfLib.Filters;

namespace Code.SwfLib.Filters {
    public class FilterFactory {

        public BaseFilter Create(FilterType type) {
            switch (type) {
                case FilterType.DropShadow:
                    return new DropShadowFilter();
                case FilterType.Blur:
                    return new BlurFilter();
                case FilterType.Glow:
                    return new GlowFilter();
                case FilterType.Bevel:
                    return new BevelFilter();
                case FilterType.GradientGlow:
                    return new GradientGlowFilter();
                case FilterType.Convolution:
                    return new ConvolutionFilter();
                case FilterType.ColorMatrix:
                    return new ColorMatrixFilter();
                case FilterType.GradientBevel:
                    return new GradientBevelFilter();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
