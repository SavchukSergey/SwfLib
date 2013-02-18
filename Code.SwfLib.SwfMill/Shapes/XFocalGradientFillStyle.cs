using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;

namespace Code.SwfLib.SwfMill.Shapes {
    public static class XFocalGradientFillStyle {

        public const string FOCAL_GRADIENT = "FocalGradient";

        public static XElement ToXml(FocalGradientFillStyleRGB fillStyle) {
            var res = new XElement(FOCAL_GRADIENT);
            AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
            AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
            AddMatrix(res, fillStyle.GradientMatrix);
            res.Add(XGradientRecords.ToXml(fillStyle.Gradient.GradientRecords));
            AddFocalPoint(res, fillStyle.Gradient.FocalPoint);
            return res;
        }

        public static XElement ToXml(FocalGradientFillStyleRGBA fillStyle) {
            var res = new XElement(FOCAL_GRADIENT);
            AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
            AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
            AddMatrix(res, fillStyle.GradientMatrix);
            res.Add(XGradientRecords.ToXml(fillStyle.Gradient.GradientRecords));
            AddFocalPoint(res, fillStyle.Gradient.FocalPoint);
            return res;
        }


        public static FocalGradientFillStyleRGB FromXmlRGB(XElement xFillStyle) {
            var res = new FocalGradientFillStyleRGB {
                Gradient = new FocalGradientRGB {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
                    FocalPoint = GetFocalPoint(xFillStyle)
                },
                GradientMatrix = GetMatrix(xFillStyle)
            };
            var xGradientColors = xFillStyle.Element("gradientColors");
            XGradientRecords.FromXml(xGradientColors, res.Gradient.GradientRecords);
            return res;
        }

        public static FocalGradientFillStyleRGBA FromXmlRGBA(XElement xFillStyle) {
            var res = new FocalGradientFillStyleRGBA {
                Gradient = new FocalGradientRGBA {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
                    FocalPoint = GetFocalPoint(xFillStyle)
                },
                GradientMatrix = GetMatrix(xFillStyle)
            };
            var xGradientColors = xFillStyle.Element("gradientColors");
            XGradientRecords.FromXml(xGradientColors, res.Gradient.GradientRecords);
            return res;
        }

        private static void AddSpreadMode(XElement xml, SpreadMode mode) {
            xml.Add(new XAttribute("spreadMode", mode.ToString()));
        }

        private static SpreadMode GetSpreadMode(XElement xFillStyle) {
            var xMode = xFillStyle.Attribute("spreadMode");
            var res = SpreadMode.Pad;
            if (xMode == null) return res;
            return (SpreadMode)Enum.Parse(typeof(SpreadMode), xMode.Value);
        }

        private static void AddMatrix(XElement xml, SwfMatrix matrix) {
            xml.Add(new XElement("matrix", XMatrix.ToXml(matrix)));
        }

        private static SwfMatrix GetMatrix(XElement xFillStyle) {
            var xMatrix = xFillStyle.Element("matrix");
            return XMatrix.FromXml(xMatrix.Element(XMatrix.TAG_NAME));
        }


        private static void AddInterpolationMode(XElement xml, InterpolationMode mode) {
            xml.Add(new XAttribute("interpolationMode", mode.ToString()));
        }

        private static InterpolationMode GetInterpolationMode(XElement xFillStyle) {
            var xMode = xFillStyle.Attribute("interpolationMode");
            var res = InterpolationMode.Normal;
            if (xMode == null) return res;
            return (InterpolationMode)Enum.Parse(typeof(InterpolationMode), xMode.Value);
        }

        private static void AddFocalPoint(XElement xml, double val) {
            xml.Add(new XAttribute("focalPoint", CommonFormatter.Format(val)));
        }

        private static double GetFocalPoint(XElement xFillStyle) {
            var xFocalPoint = xFillStyle.Attribute("focalPoint");
            return CommonFormatter.ParseDouble(xFocalPoint.Value);
        }


    }
}
