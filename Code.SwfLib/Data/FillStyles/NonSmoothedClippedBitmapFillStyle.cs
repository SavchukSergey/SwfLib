namespace Code.SwfLib.Data.FillStyles
{
    public class NonSmoothedClippedBitmapFillStyle : FillStyle {

        public ushort ObjectID;

        public SwfMatrix BitmapMatrix;

        public override FillStyleType Type
        {
            get { return FillStyleType.NonSmoothedClippedBitmap; }
        }

    }
}