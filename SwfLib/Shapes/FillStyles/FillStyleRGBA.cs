namespace SwfLib.Shapes.FillStyles {
    public abstract class FillStyleRGBA {

        public abstract FillStyleType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg);

    }
}