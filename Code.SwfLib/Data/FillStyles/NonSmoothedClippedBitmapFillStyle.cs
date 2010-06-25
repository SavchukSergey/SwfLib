namespace Code.SwfLib.Data.FillStyles
{
    public class NonSmoothedClippedBitmapFillStyle : FillStyle {

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

        public override FillStyleType Type
        {
            get { return FillStyleType.NonSmoothedClippedBitmap; }
        }

    }
}