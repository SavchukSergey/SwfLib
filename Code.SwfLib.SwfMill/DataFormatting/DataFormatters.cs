namespace Code.SwfLib.SwfMill.DataFormatting {
    public class DataFormatters {

        public DataFormatters() {
            Rectangle = new RectangleDataFormatter(this);
            Matrix = new MatrixFormatter(this);
            FillStyleRGB = new FillStyleRGBFormatter(this);
            FillStyleRGBA = new FillStyleRGBAFormatter(this);
            ColorTransformRGBA = new ColorTransformRGBAFormatter(this);
        }

        public readonly RectangleDataFormatter Rectangle;

        public readonly ColorTransformRGBAFormatter ColorTransformRGBA;

        public readonly MatrixFormatter Matrix;

        public readonly FillStyleRGBFormatter FillStyleRGB;

        public readonly FillStyleRGBAFormatter FillStyleRGBA;

    }
}
