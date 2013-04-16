namespace Code.SwfLib.Shapes.Records {
    public interface IShapeRecord {

        ShapeRecordType Type { get; }

        TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg);
    }
}
