namespace Code.SwfLib.SwfMill.DataFormatting {
    public class DataFormatters {

        public DataFormatters() {
            Matrix = new MatrixFormatter(this);
            FillStyleRGB = new FillStyleRGBFormatter(this);
            FillStyleRGBA = new FillStyleRGBAFormatter(this);
        }

        public readonly MatrixFormatter Matrix;

        public readonly FillStyleRGBFormatter FillStyleRGB;

        public readonly FillStyleRGBAFormatter FillStyleRGBA;

    }
}
