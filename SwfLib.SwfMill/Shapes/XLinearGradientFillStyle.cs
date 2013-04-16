using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using SwfLib.Data;
using SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Shapes {
    public static class XLinearGradientFillStyle {

        public const string LINEAR_GRADIENT = "LinearGradient";

        public static XElement ToXml(LinearGradientFillStyleRGB fillStyle) {
            var res = new XElement(LINEAR_GRADIENT);
            AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
            AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
            AddMatrix(res, fillStyle.GradientMatrix);
            res.Add(XGradientRecords.ToXml(fillStyle.Gradient.GradientRecords));
            return res;
        }

        public static XElement ToXml(LinearGradientFillStyleRGBA fillStyle) {
            var res = new XElement(LINEAR_GRADIENT);
            AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
            AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
            AddMatrix(res, fillStyle.GradientMatrix);
            res.Add(XGradientRecords.ToXml(fillStyle.Gradient.GradientRecords));
            return res;
        }

        public static LinearGradientFillStyleRGB FromXmlRGB(XElement xFillStyle) {
            var res = new LinearGradientFillStyleRGB {
                Gradient = new GradientRGB {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
                },
                GradientMatrix = GetMatrix(xFillStyle)
            };
            var xGradientColors = xFillStyle.Element("gradientColors");
            XGradientRecords.FromXml(xGradientColors, res.Gradient.GradientRecords);
            return res;
        }

        public static LinearGradientFillStyleRGBA FromXmlRGBA(XElement xFillStyle) {
            var res = new LinearGradientFillStyleRGBA {
                Gradient = new GradientRGBA {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
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

        private static void AddInterpolationMode(XElement xml, InterpolationMode mode) {
            xml.Add(new XAttribute("interpolationMode", mode.ToString()));
        }

        private static InterpolationMode GetInterpolationMode(XElement xFillStyle) {
            var xMode = xFillStyle.Attribute("interpolationMode");
            var res = InterpolationMode.Normal;
            if (xMode == null) return res;
            return (InterpolationMode)Enum.Parse(typeof(InterpolationMode), xMode.Value);
        }

        private static void AddMatrix(XElement xml, SwfMatrix matrix) {
            xml.Add(new XElement("matrix", XMatrix.ToXml(matrix)));
        }

        private static SwfMatrix GetMatrix(XElement xFillStyle) {
            var xMatrix = xFillStyle.RequiredElement("matrix");
            return XMatrix.FromXml(xMatrix.Element(XMatrix.TAG_NAME));
        }
    }
}
