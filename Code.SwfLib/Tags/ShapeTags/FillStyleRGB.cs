using Code.SwfLib.Data;
using Code.SwfLib.Data.Gradients;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Tags.ShapeTags {
    public struct FillStyleRGB {

        public FillStyleType FillStyleType;

        public SwfRGB Color;

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public FocalGradient FocalGradient;

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

    }
}