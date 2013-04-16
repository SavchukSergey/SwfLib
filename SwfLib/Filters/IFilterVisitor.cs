using SwfLib.Filters;

namespace Code.SwfLib.Filters {
    public interface IFilterVisitor<TArg, TResult> {

        TResult Visit(DropShadowFilter filter, TArg arg);

        TResult Visit(BlurFilter filter, TArg arg);

        TResult Visit(GlowFilter filter, TArg arg);

        TResult Visit(BevelFilter filter, TArg arg);

        TResult Visit(GradientGlowFilter filter, TArg arg);

        TResult Visit(ConvolutionFilter filter, TArg arg);

        TResult Visit(ColorMatrixFilter filter, TArg arg);

        TResult Visit(GradientBevelFilter filter, TArg arg);

    }
}
