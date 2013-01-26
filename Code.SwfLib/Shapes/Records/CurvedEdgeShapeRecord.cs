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

        public override string ToString() {
            return string.Format("CurveTo: anchor ({0}, {1}), control: ({2}, {3})", AnchorDeltaX, AnchorDeltaY, ControlDeltaX, ControlDeltaY);
        }
    }
}
