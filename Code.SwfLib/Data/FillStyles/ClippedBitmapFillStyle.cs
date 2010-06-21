namespace Code.SwfLib.Data.FillStyles
{
    public class ClippedBitmapFillStyle : FillStyle {

        public ushort ObjectID;

        public SwfMatrix BitmapMatrix;

        public override FillStyleType Type
        {
            get { return FillStyleType.ClippedBitmap; }
        }
       
    }
}