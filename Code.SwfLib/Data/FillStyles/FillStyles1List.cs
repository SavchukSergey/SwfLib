namespace Code.SwfLib.Data.FillStyles {
    public class FillStyles1List : FillStylesListBase {
        public override bool IsValid(FillStyle style) {
            if (style == null) return false;
            switch (style.Type) {
                case FillStyleType.ClippedBitmap:
                case FillStyleType.SolidRGB:
                case FillStyleType.LinearGradient:
                case FillStyleType.NonSmoothedClippedBitmap:
                    return true;
                default:
                    return false;
            }
        }
    }
}
