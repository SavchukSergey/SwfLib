using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class NonSmoothedClippedBitmapFillStyle : IDefineShape1FillStyle {

        public ushort ObjectID;

        public SwfMatrix BitmapMatrix;

        public FillStyleType Type
        {
            get { return FillStyleType.NonSmoothedClippedBitmap; }
        }

        public object AcceptVisitor(IFillStyleVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
