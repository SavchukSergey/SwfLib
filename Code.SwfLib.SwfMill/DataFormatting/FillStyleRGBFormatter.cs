using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class FillStyleRGBFormatter : DataFormatterBase<FillStyleRGB> {
        public FillStyleRGBFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out FillStyleRGB data) {
            data = new FillStyleRGB();
            switch (element.Name.LocalName) {
                case "LinearGradient":
                    data.FillStyleType = FillStyleType.LinearGradient;
                    break;
                case "Solid":
                    data.FillStyleType = FillStyleType.SolidColor;
                    break;
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

        protected override void AcceptElement(XElement element, ref FillStyleRGB data) {
            switch (data.FillStyleType) {
                case FillStyleType.SolidColor:
                    switch (element.Name.LocalName) {
                        case "color":
                            data.Color = XColorRGB.FromXml(element.Element("Color"));
                            break;
                        default:
                            OnUnknownElementFound(element);
                            break;
                    }
                    break;
                case FillStyleType.LinearGradient:
                    switch (element.Name.LocalName) {
                        case "matrix":
                            data.GradientMatrix = XMatrix.FromXml(element.Element("Transform"));
                            break;
                        case "gradientColors":
                            ParseGradientColorsTo(element, data.Gradient.GradientRecords);
                            break;
                        default:
                            OnUnknownElementFound(element);
                            break;
                    }
                    break;
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

        protected override void AcceptAttribute(XAttribute attrib, ref FillStyleRGB data) {
            switch (data.FillStyleType) {
                case FillStyleType.SolidColor:
                    switch (attrib.Name.LocalName) {
                        default:
                            OnUnknownAttributeFound(attrib);
                            break;
                    }
                    break;
                case FillStyleType.LinearGradient:
                    switch (attrib.Name.LocalName) {
                        default:
                            OnUnknownAttributeFound(attrib);
                            break;
                    }
                    break;
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

        public override XElement Format(ref FillStyleRGB data) {
            switch (data.FillStyleType) {
                case FillStyleType.SolidColor:
                    return FormatSolidColorRGBFillStyle(ref data);
                case FillStyleType.LinearGradient:
                    return FormatLinearGradientRGBFillStyle(ref data);
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
        private XElement FormatNonSmoothedClippedFillStyle(ref FillStyleRGB style) {
            var elem = new XElement(XName.Get("ClippedBitmap2"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatNonSmoothedRepeatingBitmapFillStyle(ref FillStyleRGB style) {
            var elem = new XElement(XName.Get("TiledBitmap2"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatClippedBitmapFillStyle(ref FillStyleRGB style) {
            var elem = new XElement(XName.Get("ClippedBitmap"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private XElement FormatRepeatingBitmapFillStyle(ref FillStyleRGB style) {
            var elem = new XElement(XName.Get("TiledBitmap"));
            elem.Add(new XAttribute("objectID", style.BitmapID));
            elem.Add(new XElement("matrix", XMatrix.ToXml(style.BitmapMatrix)));
            return elem;
        }

        private static XElement FormatFocalGradientRGBFillStyle(ref FillStyleRGB style) {
            throw new NotImplementedException();
        }

        private static XElement FormatRadialGradientRGBFillStyle(ref FillStyleRGB style) {
            throw new NotImplementedException();
        }

        private XElement FormatLinearGradientRGBFillStyle(ref FillStyleRGB style) {
            return XFillStyle.ToXml(style);
        }

        private XElement FormatSolidColorRGBFillStyle(ref FillStyleRGB style) {
            return new XElement(XName.Get("Solid"),
                new XElement("color", XColorRGB.ToXml(style.Color)));
        }

        private void ParseGradientColorsTo(XElement element, IList<GradientRecordRGB> records) {
            foreach (var item in element.Elements(XName.Get("GradientItem"))) {
                var record = XGradientRecordRGB.FromXml(item);
                records.Add(record);
            }
        }

    }
}
