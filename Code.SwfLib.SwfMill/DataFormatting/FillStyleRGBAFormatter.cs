using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class FillStyleRGBAFormatter : DataFormatterBase<FillStyleRGBA> {
        public FillStyleRGBAFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out FillStyleRGBA data) {
            data = new FillStyleRGBA();
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

        protected override void AcceptElement(XElement element, ref FillStyleRGBA data) {
            switch (data.FillStyleType) {
                case FillStyleType.SolidColor:
                    switch (element.Name.LocalName) {
                        case "color":
                            data.Color = XColorRGBA.FromXml(element.Element("Color"));
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


        protected override void AcceptAttribute(XAttribute attrib, ref FillStyleRGBA data) {
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

        public override XElement Format(ref FillStyleRGBA data) {
            switch (data.FillStyleType) {
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

        private XElement FormatLinearGradientRGBFillStyle(ref FillStyleRGBA style) {
            return new XElement(XName.Get("LinearGradient"),
                new XElement("matrix", XMatrix.ToXml(style.GradientMatrix)),
                FormatGradientRecord(style.Gradient.GradientRecords)
                );
        }

        private XElement FormatGradientRecord(IEnumerable<GradientRecordRGBA> gradients) {
            var list = new XElement(XName.Get("gradientColors"));
            foreach (var gradient in gradients) {
                var color = gradient.Color;
                list.Add(new XElement(XName.Get("GradientItem"),
                    new XAttribute(XName.Get("position"), gradient.Ratio),
                    new XElement("color", XColorRGBA.ToXml(color))
                ));
            }
            return list;
        }


        private void ParseGradientColorsTo(XElement element, IList<GradientRecordRGBA> records) {
            foreach (var item in element.Elements(XName.Get("GradientItem"))) {
                var record = XGradientRecordRGBA.FromXml(item);
                records.Add(record);
            }
        }

    }
}
