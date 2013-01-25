namespace Code.SwfLib.Shapes.Records {
    public class CurvedEdgeShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {

        public int ControlDeltaX;

        public int ControlDeltaY;

        public int AnchorDeltaX;

        public int AnchorDeltaY;

        public ShapeRecordType Type {
            get { return ShapeRecordType.CurvedEdgeRecord; }
        }
    }
}
