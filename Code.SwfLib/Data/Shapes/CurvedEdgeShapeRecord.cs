using System;

namespace Code.SwfLib.Data.Shapes {
    public class CurvedEdgeShapeRecord : ShapeRecord {

        public int ControlDeltaX;

        public int ControlDeltaY;

        public int AnchorDeltaX;

        public int AnchorDeltaY;

        public override ShapeRecordType Type {
            get { return ShapeRecordType.CurvedEdgeRecord; }
        }
    }
}
