using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class LinearGradientFillStyle : IDefineShape1FillStyle {

        public SwfMatrix GradientMatrix;

        public FillStyleType Type {
            get { return FillStyleType.LinearGradient; }
        }

        public object AcceptVisitor(IFillStyleVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
