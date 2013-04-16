using Code.SwfLib.Data;
using SwfLib.Data;
using SwfLib.Shapes.FillStyles;

namespace SwfLib.Shapes.LineStyles {
    public struct LineStyleEx {

        public ushort Width;

        public CapStyle StartCapStyle;

        public JoinStyle JoinStyle;

        public bool HasFill;

        public bool NoHScale;

        public bool NoVScale;

        public bool PixelHinting;

        public byte Reserved;

        public bool NoClose;

        public CapStyle EndCapStyle;

        public double MilterLimitFactor;

        public SwfRGBA Color;

        public FillStyleRGBA FillStyle;
    }
}
