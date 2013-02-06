using Code.SwfLib.Data;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.LineStyles;

namespace Code.SwfLib.Tags.ShapeTags {
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
