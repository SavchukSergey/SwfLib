using Code.SwfLib.Shapes.FillStyles;

namespace SwfLib.Shapes.FillStyles {
    public interface IFillStyleRGBVisitor<TArg, TResult> {

        TResult Visit(SolidFillStyleRGB fillStyle, TArg arg);

        TResult Visit(LinearGradientFillStyleRGB fillStyle, TArg arg);

        TResult Visit(RadialGradientFillStyleRGB fillStyle, TArg arg);

        TResult Visit(FocalGradientFillStyleRGB fillStyle, TArg arg);

        TResult Visit(BitmapFillStyleRGB fillStyle, TArg arg);

    }
}
