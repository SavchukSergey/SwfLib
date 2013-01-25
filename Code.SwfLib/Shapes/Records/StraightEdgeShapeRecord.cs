namespace Code.SwfLib.Shapes.Records {
    public class StraightEdgeShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {

        public int DeltaX;

        public int DeltaY;

        public ShapeRecordType Type {
            get { return ShapeRecordType.StraightEdge; }
        }

        public TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
