namespace Code.SwfLib.Data.FillStyles
{
    public class ClippedBitmapFillStyle : FillStyle {

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

        public override FillStyleType Type
        {
            get { return FillStyleType.ClippedBitmap; }
        }
       
    }
}