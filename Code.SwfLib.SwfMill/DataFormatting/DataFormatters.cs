namespace Code.SwfLib.SwfMill.DataFormatting {
    public class DataFormatters {

        public DataFormatters() {
            FillStyleRGB = new FillStyleRGBFormatter(this);
            FillStyleRGBA = new FillStyleRGBAFormatter(this);
        }

        public readonly FillStyleRGBFormatter FillStyleRGB;

        public readonly FillStyleRGBAFormatter FillStyleRGBA;

    }
}
