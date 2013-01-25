using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XFillStyle {

        public static XElement ToXml(FillStyleRGB fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.FillStyleType));
            switch (fillStyle.FillStyleType) {
                case FillStyleType.LinearGradient:
                    AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
                    AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
                    AddMatrix(res, fillStyle.GradientMatrix);
                    AddGradientColors(res, fillStyle.Gradient.GradientRecords);
                    break;
                case FillStyleType.SolidColor:
                    res.Add(new XElement("color", XColorRGB.ToXml(fillStyle.Color)));
                    break;
            }
            return res;
        }

        public static XElement ToXml(FillStyleRGBA fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.FillStyleType));
            switch (fillStyle.FillStyleType) {
                case FillStyleType.LinearGradient:
                    AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
                    AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
                    AddMatrix(res, fillStyle.GradientMatrix);
                    AddGradientColors(res, fillStyle.Gradient.GradientRecords);
                    break;
                case FillStyleType.SolidColor:
                    res.Add(new XElement("color", XColorRGBA.ToXml(fillStyle.Color)));
                    break;
            }
            return res;
        }

        public static FillStyleRGB FromXmlRGB(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case "Solid":
                    return ParseSolidRGB(xFillStyle);
                    //TODO: other fill styles
                default:
                    throw new NotSupportedException();
            }
        }

        public static FillStyleRGBA FromXmlRGBA(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case "Solid":
                    return ParseSolidRGBA(xFillStyle);
                //TODO: other fill styles
                default:
                    throw new NotSupportedException();
            }
        }

        private static FillStyleRGB ParseSolidRGB(XElement xFillStyle) {
            var xColor = xFillStyle.Element("color");
            return new FillStyleRGB {
                FillStyleType = FillStyleType.SolidColor,
                Color = XColorRGB.FromXml(xColor)
            };
        }

        private static FillStyleRGBA ParseSolidRGBA(XElement xFillStyle) {
            var xColor = xFillStyle.Element("color");
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.SolidColor,
                Color = XColorRGBA.FromXml(xColor)
            };
        }

        private static void AddGradientColors(XElement xml, IEnumerable<GradientRecordRGB> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGB.ToXml(record);
                xColors.Add(xRecord);
            }
            xml.Add(xColors);
        }

        private static void AddGradientColors(XElement xml, IEnumerable<GradientRecordRGBA> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGBA.ToXml(record);
                xColors.Add(xRecord);
            }
            xml.Add(xColors);
        }

        private static void AddMatrix(XElement xml, SwfMatrix matrix) {
            xml.Add(new XElement("matrix", XMatrix.ToXml(matrix)));
        }

        private static void AddSpreadMode(XElement xml, SpreadMode mode) {
            xml.Add(new XAttribute("spreadMode", mode.ToString()));
        }

        private static void AddInterpolationMode(XElement xml, InterpolationMode mode) {
            xml.Add(new XAttribute("interpolationMode", mode.ToString()));
        }

        private static string GetNodeName(FillStyleType type) {
            switch (type) {
                case FillStyleType.LinearGradient:
                    return "LinearGradient";
                case FillStyleType.SolidColor:
                    return "Solid";
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
