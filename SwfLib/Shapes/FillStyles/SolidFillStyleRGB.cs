using Code.SwfLib.Data;
using SwfLib.Data;

namespace Code.SwfLib.Shapes.FillStyles {
    public class SolidFillStyleRGB : FillStyleRGB {

        public SwfRGB Color;

        public override FillStyleType Type {
            get { return FillStyleType.SolidColor; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
