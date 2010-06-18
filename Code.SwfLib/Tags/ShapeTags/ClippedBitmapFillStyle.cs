using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class ClippedBitmapFillStyle : IDefineShape1FillStyle {

        public ushort ObjectID;

        public SwfMatrix BitmapMatrix;

        public FillStyleType Type
        {
            get { return FillStyleType.ClippedBitmap; }
        }

        public object AcceptVisitor(IFillStyleVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
