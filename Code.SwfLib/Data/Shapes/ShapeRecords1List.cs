namespace Code.SwfLib.Data.Shapes {
    public class ShapeRecords1List : ShapeRecordsListBase {

        public override bool IsValid(ShapeRecord item) {
            if (item == null) return false;
            switch (item.Type) {
                case ShapeRecordType.EndRecord:
                case ShapeRecordType.StyleChangeRecord:
                case ShapeRecordType.StraightEdge:
                case ShapeRecordType.CurvedEdgeRecord:
                    return true;
                default:
                    return false;
            }
        }


    }
}
