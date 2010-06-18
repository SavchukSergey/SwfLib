using System;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class SolidRGBFillStyle : IDefineShape1FillStyle {

        public SwfRGB Color;

        public FillStyleType Type {
            get { return FillStyleType.Solid; }
        }

        public object AcceptVisitor(IFillStyleVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
