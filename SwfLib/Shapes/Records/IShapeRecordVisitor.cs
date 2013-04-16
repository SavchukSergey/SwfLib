namespace Code.SwfLib.Shapes.Records {
    public interface IShapeRecordVisitor<TArg, TResult> {

        TResult Visit(EndShapeRecord record, TArg arg);

        TResult Visit(StyleChangeShapeRecordRGB record, TArg arg);

        TResult Visit(StyleChangeShapeRecordRGBA record, TArg arg);

        TResult Visit(StyleChangeShapeRecordEx record, TArg arg);

        TResult Visit(StraightEdgeShapeRecord record, TArg arg);

        TResult Visit(CurvedEdgeShapeRecord record, TArg arg);

    }
}
