namespace Code.SwfLib.Shapes.Records {
    public class EndShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {
        
        public ShapeRecordType Type {
            get { return ShapeRecordType.EndRecord; }
        }

        public TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
