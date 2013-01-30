using System;
using System.Xml.Linq;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class FillStyleRGBAFormatter : DataFormatterBase<FillStyleRGBA> {
        public FillStyleRGBAFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out FillStyleRGBA data) {
            data = new FillStyleRGBA();
            switch (element.Name.LocalName) {
                case "ClippedBitmap":
                    data.FillStyleType = FillStyleType.ClippedBitmap;
                    break;
                case "ClippedBitmap2":
                    data.FillStyleType = FillStyleType.NonSmoothedClippedBitmap;
                    break;
                case "TiledBitmap2":
                    data.FillStyleType = FillStyleType.NonSmoothedRepeatingBitmap;
                    break;
                default:
                    throw new NotSupportedException("Unknown fill style " + element.Name.LocalName);
            }
        }

        protected override void AcceptElement(XElement element, ref FillStyleRGBA data) {
            switch (data.FillStyleType) {
                case FillStyleType.RadialGradient:
                    throw new NotImplementedException();
                case FillStyleType.FocalGradient:
                    throw new NotImplementedException();
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    switch (element.Name.LocalName) {
                        case "matrix":
                            data.BitmapMatrix = XMatrix.FromXml(element.Element("Transform"));
                            break;
                        default:
                            OnUnknownElementFound(element);
                            break;
                    }
                    break;
                default:
                    throw new NotSupportedException("Fill style " + data.FillStyleType + " is not supported");
            }

        }


        protected override void AcceptAttribute(XAttribute attrib, ref FillStyleRGBA data) {
            switch (data.FillStyleType) {
                case FillStyleType.RadialGradient:
                    throw new NotImplementedException();
                case FillStyleType.FocalGradient:
                    throw new NotImplementedException();
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    switch (attrib.Name.LocalName) {
                        case OBJECT_ID_ATTRIB:
                            data.BitmapID = ushort.Parse(attrib.Value);
                            break;
                        default:
                            OnUnknownAttributeFound(attrib);
                            break;
                    }
                    break;
                default:
                    throw new NotSupportedException("Fill style " + data.FillStyleType + " is not supported");
            }

        }

        public override XElement Format(ref FillStyleRGBA data) {
            switch (data.FillStyleType) {
                case FillStyleType.RadialGradient:
                    return FormatRadialGradientRGBFillStyle(ref data);
                case FillStyleType.FocalGradient:
                    return FormatFocalGradientRGBFillStyle(ref data);
                case FillStyleType.RepeatingBitmap:
                    return FormatRepeatingBitmapFillStyle(ref data);
                case FillStyleType.ClippedBitmap:
                    return FormatClippedBitmapFillStyle(ref data);
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    return FormatNonSmoothedRepeatingBitmapFillStyle(ref data);
                case FillStyleType.NonSmoothedClippedBitmap:
                    return FormatNonSmoothedClippedFillStyle(ref data);
                default:
                    throw new NotSupportedException("Fill style " + data.FillStyleType + " is not supported");
            }
        }
        private XElement FormatNonSmoothedClippedFillStyle(ref FillStyleRGBA style) {
            var elem = new XElement(XName.Get("ClippedBitmap2"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatNonSmoothedRepeatingBitmapFillStyle(ref FillStyleRGBA style) {
            var elem = new XElement(XName.Get("TiledBitmap2"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatClippedBitmapFillStyle(ref FillStyleRGBA style) {
            var elem = new XElement(XName.Get("ClippedBitmap"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatRepeatingBitmapFillStyle(ref FillStyleRGBA style) {
            var elem = new XElement(XName.Get("TiledBitmap"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private static XElement FormatFocalGradientRGBFillStyle(ref FillStyleRGBA style) {
            throw new NotImplementedException();
        }

        private static XElement FormatRadialGradientRGBFillStyle(ref FillStyleRGBA style) {
            throw new NotImplementedException();
        }

    }
}
