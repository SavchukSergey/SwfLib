using Code.SwfLib.Data.Gradients;

namespace Code.SwfLib.Data.FillStyles {
    public struct FillStyle {

        public FillStyleType FillStyleType;

        public SwfRGB ColorRGB;

        public SwfRGBA ColorRGBA;

        public SwfMatrix GradientMatrix;

        public GradientRGB Gradient;

        public FocalGradient FocalGradient;

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

    }
}