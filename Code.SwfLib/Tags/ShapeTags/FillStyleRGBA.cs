using Code.SwfLib.Data;
using Code.SwfLib.Data.Gradients;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Tags.ShapeTags {
    public struct FillStyleRGBA {

        public FillStyleType FillStyleType;

        public SwfRGBA Color;

        public SwfMatrix GradientMatrix;

        public GradientRGBA Gradient;

        public FocalGradient FocalGradient;

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

    }
}