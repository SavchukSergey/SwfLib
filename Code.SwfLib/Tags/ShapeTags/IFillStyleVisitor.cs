namespace Code.SwfLib.Tags.ShapeTags {
    public interface IFillStyleVisitor {

        object Visit(ClippedBitmapFillStyle style);

        object Visit(LinearGradientFillStyle style);

        object Visit(NonSmoothedClippedBitmapFillStyle style);

        object Visit(SolidRGBFillStyle style);

    }
}
