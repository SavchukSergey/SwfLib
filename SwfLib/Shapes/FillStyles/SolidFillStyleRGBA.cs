using Code.SwfLib.Data;

namespace Code.SwfLib.Shapes.FillStyles {
    public class SolidFillStyleRGBA : FillStyleRGBA {

        public SwfRGBA Color;

        public override FillStyleType Type {
            get { return FillStyleType.SolidColor; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
