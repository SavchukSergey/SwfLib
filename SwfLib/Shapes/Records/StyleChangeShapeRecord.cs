namespace SwfLib.Shapes.Records {
    public abstract class StyleChangeShapeRecord : IShapeRecord {

        public uint? FillStyle0;

        public uint? FillStyle1;

        public uint? LineStyle;

        public bool StateMoveTo;

        public int MoveDeltaX;

        public int MoveDeltaY;

        public bool StateNewStyles;

        public ShapeRecordType Type {
            get { return ShapeRecordType.StyleChangeRecord; }
        }

        public abstract TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg);

    }
}
