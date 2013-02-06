using Code.SwfLib.Data;
using Code.SwfLib.Gradients;

namespace Code.SwfLib.Shapes.FillStyles {
    public struct FillStyleRGBA {

        public FillStyleType FillStyleType;

        public SwfRGBA Color;

        public SwfMatrix GradientMatrix;

        public GradientRGBA Gradient;

        public FocalGradientRGBA FocalGradient;

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

    }
}