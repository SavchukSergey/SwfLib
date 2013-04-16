using System;
using System.Xml.Linq;
using SwfLib.Shapes.FillStyles;

namespace SwfLib.SwfMill.Shapes {
    public class XFillStyle {

        public static XElement ToXml(FillStyleRGB fillStyle) {
            switch (fillStyle.Type) {
                case FillStyleType.SolidColor:
                    return XSolidFillStyle.ToXml((SolidFillStyleRGB)fillStyle);
                case FillStyleType.LinearGradient:
                    return XLinearGradientFillStyle.ToXml((LinearGradientFillStyleRGB)fillStyle);
                case FillStyleType.RadialGradient:
                    return XRadialGradientFillStyle.ToXml((RadialGradientFillStyleRGB)fillStyle);
                case FillStyleType.FocalGradient:
                    return XFocalGradientFillStyle.ToXml((FocalGradientFillStyleRGB)fillStyle);
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    return XBitmapFillStyle.ToXml((BitmapFillStyleRGB)fillStyle);
                default:
                    throw new NotSupportedException();
            }
        }

        public static XElement ToXml(FillStyleRGBA fillStyle) {
            switch (fillStyle.Type) {
                case FillStyleType.SolidColor:
                    return XSolidFillStyle.ToXml((SolidFillStyleRGBA)fillStyle);
                case FillStyleType.LinearGradient:
                    return XLinearGradientFillStyle.ToXml((LinearGradientFillStyleRGBA)fillStyle);
                case FillStyleType.RadialGradient:
                    return XRadialGradientFillStyle.ToXml((RadialGradientFillStyleRGBA)fillStyle);
                case FillStyleType.FocalGradient:
                    return XFocalGradientFillStyle.ToXml((FocalGradientFillStyleRGBA)fillStyle);
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    return XBitmapFillStyle.ToXml((BitmapFillStyleRGBA)fillStyle);
                default:
                    throw new NotSupportedException();
            }
        }

        public static FillStyleRGB FromXmlRGB(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case XSolidFillStyle.SOLID:
                    return XSolidFillStyle.FromXmlRGB(xFillStyle);
                case XLinearGradientFillStyle.LINEAR_GRADIENT:
                    return XLinearGradientFillStyle.FromXmlRGB(xFillStyle);
                case XRadialGradientFillStyle.RADIAL_GRADIENT:
                    return XRadialGradientFillStyle.FromXmlRGB(xFillStyle);
                case XFocalGradientFillStyle.FOCAL_GRADIENT:
                    return XFocalGradientFillStyle.FromXmlRGB(xFillStyle);
                case XBitmapFillStyle.REPEATING_BITMAP:
                    return XBitmapFillStyle.ParseRepeatingBitmapRGB(xFillStyle);
                case XBitmapFillStyle.CLIPPED_BITMAP:
                    return XBitmapFillStyle.ParseClippedBitmapRGB(xFillStyle);
                case XBitmapFillStyle.NON_SMOOTHED_REPEATING_BITMAP:
                    return XBitmapFillStyle.ParseNonSmoothedRepeatingBitmapRGB(xFillStyle);
                case XBitmapFillStyle.NON_SMOOTHED_CLIPPED_BITMAP:
                    return XBitmapFillStyle.ParseNonSmoothedClippedBitmapRGB(xFillStyle);
                default:
                    throw new NotSupportedException();
            }
        }

        public static FillStyleRGBA FromXmlRGBA(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case XSolidFillStyle.SOLID:
                    return XSolidFillStyle.FromXmlRGBA(xFillStyle);
                case XLinearGradientFillStyle.LINEAR_GRADIENT:
                    return XLinearGradientFillStyle.FromXmlRGBA(xFillStyle);
                case XRadialGradientFillStyle.RADIAL_GRADIENT:
                    return XRadialGradientFillStyle.FromXmlRGBA(xFillStyle);
                case XFocalGradientFillStyle.FOCAL_GRADIENT:
                    return XFocalGradientFillStyle.FromXmlRGBA(xFillStyle);
                case XBitmapFillStyle.REPEATING_BITMAP:
                    return XBitmapFillStyle.ParseRepeatingBitmapRGBA(xFillStyle);
                case XBitmapFillStyle.CLIPPED_BITMAP:
                    return XBitmapFillStyle.ParseClippedBitmapRGBA(xFillStyle);
                case XBitmapFillStyle.NON_SMOOTHED_REPEATING_BITMAP:
                    return XBitmapFillStyle.ParseNonSmoothedRepeatingBitmapRGBA(xFillStyle);
                case XBitmapFillStyle.NON_SMOOTHED_CLIPPED_BITMAP:
                    return XBitmapFillStyle.ParseNonSmoothedClippedBitmapRGBA(xFillStyle);
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
