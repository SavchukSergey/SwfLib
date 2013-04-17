namespace SwfLib.Shapes.Records {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum ShapeRecordType : byte {

        EndRecord,
        StyleChangeRecord,
        StraightEdge,
        CurvedEdgeRecord

    }
}
