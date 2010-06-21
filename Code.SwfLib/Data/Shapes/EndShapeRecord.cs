namespace Code.SwfLib.Data.Shapes {
    public class EndShapeRecord : ShapeRecord {
        public override ShapeRecordType Type {
            get { return ShapeRecordType.EndRecord; }
        }
    }
}
