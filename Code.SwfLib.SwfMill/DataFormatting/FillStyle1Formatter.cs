using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Gradients;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class FillStyle1Formatter : DataFormatterBase<FillStyle> {
        public FillStyle1Formatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out FillStyle data) {
            data = new FillStyle();
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

        protected override void AcceptElement(XElement element, ref FillStyle data) {
            switch (data.FillStyleType) {
                case FillStyleType.SolidColor:
                    switch (element.Name.LocalName) {
                        case "color":
                            _formatters.ColorRGB.Parse(element.Element(XName.Get("Color")), out data.ColorRGB);
                            break;
                        default:
                            OnUnknownElementFound(element);
                            break;
                    }
                    break;
                case FillStyleType.LinearGradient:
                    switch (element.Name.LocalName) {
                        case "matrix":
                            _formatters.Matrix.Parse(element.Element(XName.Get("Transform")), out data.GradientMatrix);
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
                            _formatters.Matrix.Parse(element.Element(XName.Get("Transform")), out data.BitmapMatrix);
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


        protected override void AcceptAttribute(XAttribute attrib, ref FillStyle data) {
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

        public override XElement Format(ref FillStyle data) {
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
        private static XElement FormatNonSmoothedClippedFillStyle(ref FillStyle style) {
            throw new NotImplementedException();
        }

        private XElement FormatNonSmoothedRepeatingBitmapFillStyle(ref FillStyle style) {
            var elem = new XElement(XName.Get("TiledBitmap2"));
            elem.Add(new XAttribute(XName.Get("objectID"), style.BitmapID));
            elem.Add(new XElement(XName.Get("matrix"), _formatters.Matrix.Format(ref style.BitmapMatrix)));
            return elem;
        }

        private static XElement FormatClippedBitmapFillStyle(ref FillStyle style) {
            throw new NotImplementedException();
        }

        private static XElement FormatRepeatingBitmapFillStyle(ref FillStyle style) {
            throw new NotImplementedException();
        }

        private static XElement FormatFocalGradientRGBFillStyle(ref FillStyle style) {
            throw new NotImplementedException();
        }

        private static XElement FormatRadialGradientRGBFillStyle(ref FillStyle style) {
            throw new NotImplementedException();
        }

        private XElement FormatLinearGradientRGBFillStyle(ref FillStyle style) {
            return new XElement(XName.Get("LinearGradient"),
                new XElement(XName.Get("matrix"), _formatters.Matrix.Format(ref style.GradientMatrix)),
                FormatGradientRecord(style.Gradient.GradientRecords)
                );
        }

        private XElement FormatSolidColorRGBFillStyle(ref FillStyle style) {
            return new XElement(XName.Get("Solid"),
                new XElement(XName.Get("color"), _formatters.ColorRGB.Format(ref style.ColorRGB)));
        }

        //TODO: Interpolation and spread mode!!
        private XElement FormatGradientRecord(IEnumerable<GradientRecordRGB> gradients) {
            var list = new XElement(XName.Get("gradientColors"));
            foreach (var gradient in gradients) {
                var color = gradient.Color;
                list.Add(new XElement(XName.Get("GradientItem"),
                    new XAttribute(XName.Get("position"), gradient.Ratio),
                    new XElement(XName.Get("color"), _formatters.ColorRGB.Format(ref color))
                ));
            }
            return list;
        }

        //TODO: Interpolation and spread mode!!
        private void ParseGradientColorsTo(XElement element, IList<GradientRecordRGB> records) {
            foreach (var item in element.Elements(XName.Get("GradientItem"))) {
                GradientRecordRGB record;
                record.Ratio = byte.Parse(item.Attribute(XName.Get("position")).Value);
                _formatters.ColorRGB.Parse(item.Element("color").Element("Color"), out record.Color);
                records.Add(record);
            }
        }

    }
}
