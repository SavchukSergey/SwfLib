namespace SwfLib.Shapes.Records {
    public abstract class StyleChangeShapeRecord : IShapeRecord {

        public uint? FillStyle0;

        public uint? FillStyle1;

        public uint? LineStyle;

        public bool StateMoveTo;

        /// <summary>
        /// Gets or sets the move delta X.
        /// </summary>
        /// <value>
        /// The move delta X.
        /// </value>
        public int MoveDeltaX { get; set; }

        /// <summary>
        /// Gets or sets the move delta Y.
        /// </summary>
        public int MoveDeltaY { get; set; }

        public bool StateNewStyles;

        public ShapeRecordType Type {
            get { return ShapeRecordType.StyleChangeRecord; }
        }

        public abstract TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg);

    }
}
