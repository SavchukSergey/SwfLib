using System;

namespace SwfLib.Shapes.FillStyles {
    public class FillStyleFactory {

        public FillStyleRGB CreateRGB(FillStyleType type) {
            switch (type) {
                case FillStyleType.SolidColor:
                    return new SolidFillStyleRGB();
                case FillStyleType.LinearGradient:
                    return new LinearGradientFillStyleRGB();
                case FillStyleType.RadialGradient:
                    return new RadialGradientFillStyleRGB();
                case FillStyleType.FocalGradient:
                    return new FocalGradientFillStyleRGB();
                case FillStyleType.RepeatingBitmap:
                    return new BitmapFillStyleRGB { Smoothing = true, Mode = BitmapMode.Repeat};
                case FillStyleType.ClippedBitmap:
                    return new BitmapFillStyleRGB { Smoothing = true, Mode = BitmapMode.Clip};
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    return new BitmapFillStyleRGB { Smoothing = false, Mode = BitmapMode.Repeat };
                case FillStyleType.NonSmoothedClippedBitmap:
                    return new BitmapFillStyleRGB { Smoothing = false, Mode = BitmapMode.Clip};
                default:
                    throw new NotSupportedException();
            }
        }

        public FillStyleRGBA CreateRGBA(FillStyleType type) {
            switch (type) {
                case FillStyleType.SolidColor:
                    return new SolidFillStyleRGBA();
                case FillStyleType.LinearGradient:
                    return new LinearGradientFillStyleRGBA();
                case FillStyleType.RadialGradient:
                    return new RadialGradientFillStyleRGBA();
                case FillStyleType.FocalGradient:
                    return new FocalGradientFillStyleRGBA();
                case FillStyleType.RepeatingBitmap:
                    return new BitmapFillStyleRGBA { Smoothing = true, Mode = BitmapMode.Repeat };
                case FillStyleType.ClippedBitmap:
                    return new BitmapFillStyleRGBA { Smoothing = true, Mode = BitmapMode.Clip };
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    return new BitmapFillStyleRGBA { Smoothing = false, Mode = BitmapMode.Repeat };
                case FillStyleType.NonSmoothedClippedBitmap:
                    return new BitmapFillStyleRGBA { Smoothing = false, Mode = BitmapMode.Clip };
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
