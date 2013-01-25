namespace Code.SwfLib.Shapes.Records {
    public abstract class StyleChangeShapeRecord : IShapeRecord {

        public uint? FillStyle0;

        public uint? FillStyle1;

        public uint? LineStyle;

        public int MoveDeltaX;

        public int MoveDeltaY;

        public bool StateNewStyles;

        public ShapeRecordType Type {
            get { return ShapeRecordType.StyleChangeRecord; }
        }

    }
}
