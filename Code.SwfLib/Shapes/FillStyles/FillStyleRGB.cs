using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public struct FillStyleRGB {

        public FillStyleType FillStyleType;

        public SwfRGB Color;

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public FocalGradientRGB FocalGradient;

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

    }
}