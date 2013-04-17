namespace SwfLib.Shapes.FillStyles {
    public abstract class FillStyleRGB {

        /// <summary>
        /// Gets type of fill style.
        /// </summary>
        public abstract FillStyleType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg);

    }
}