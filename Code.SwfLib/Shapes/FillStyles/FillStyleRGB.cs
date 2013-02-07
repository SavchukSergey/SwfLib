namespace Code.SwfLib.Shapes.FillStyles {
    public abstract class FillStyleRGB {

        public abstract FillStyleType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg);

    }
}