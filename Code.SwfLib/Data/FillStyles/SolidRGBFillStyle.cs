namespace Code.SwfLib.Data.FillStyles
{
    public class SolidRGBFillStyle : FillStyle {

        public SwfRGB Color;

        public override FillStyleType Type {
            get { return FillStyleType.SolidRGB; }
        }

    }
}