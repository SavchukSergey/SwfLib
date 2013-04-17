namespace SwfLib.Shapes.FillStyles {
    public abstract class FillStyleRGBA {

        /// <summary>
        /// Gets type of fill style.
        /// </summary>
        public abstract FillStyleType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg);

    }
}