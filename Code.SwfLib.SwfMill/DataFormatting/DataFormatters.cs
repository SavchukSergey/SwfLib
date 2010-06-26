namespace Code.SwfLib.SwfMill.DataFormatting {
    public class DataFormatters {

        public DataFormatters() {
            Rectangle = new RectangleDataFormatter(this);
            ColorRGB = new ColorRGBFormatter(this);
        }

        public readonly RectangleDataFormatter Rectangle;

        public readonly ColorRGBFormatter ColorRGB;

    }
}
