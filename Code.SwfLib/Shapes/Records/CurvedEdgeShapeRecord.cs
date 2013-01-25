namespace Code.SwfLib.Shapes.Records {
    public class CurvedEdgeShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {

        public int ControlDeltaX;

        public int ControlDeltaY;

        public int AnchorDeltaX;

        public int AnchorDeltaY;

        public ShapeRecordType Type {
            get { return ShapeRecordType.CurvedEdgeRecord; }
        }

        public TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
