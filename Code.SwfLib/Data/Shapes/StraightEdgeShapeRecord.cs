namespace Code.SwfLib.Data.Shapes {
    public class StraightEdgeShapeRecord : ShapeRecord {

        public int DeltaX;

        public int DeltaY;

        public override ShapeRecordType Type {
            get { return ShapeRecordType.StraightEdge; }
        }
    }
}
