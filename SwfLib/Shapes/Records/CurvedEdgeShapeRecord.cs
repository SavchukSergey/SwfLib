namespace SwfLib.Shapes.Records {
    public class CurvedEdgeShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {

        /// <summary>
        /// Gets or sets the control delta X.
        /// </summary>
        /// <value>
        /// The control delta X.
        /// </value>
        public int ControlDeltaX { get; set; }

        /// <summary>
        /// Gets or sets the control delta Y.
        /// </summary>
        public int ControlDeltaY { get; set; }

        /// <summary>
        /// Gets or sets the anchor delta X.
        /// </summary>
        public int AnchorDeltaX { get; set; }

        /// <summary>
        /// Gets or sets the anchor delta Y.
        /// </summary>
        public int AnchorDeltaY { get; set; }

        public ShapeRecordType Type {
            get { return ShapeRecordType.CurvedEdgeRecord; }
        }

        public TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return string.Format("CurveTo: anchor ({0}, {1}), control: ({2}, {3})", AnchorDeltaX, AnchorDeltaY, ControlDeltaX, ControlDeltaY);
        }
    }
}
