using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XFillStyleRGBA {

        public static XElement ToXml(FillStyleRGBA fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.FillStyleType));
            switch (fillStyle.FillStyleType) {
                case FillStyleType.LinearGradient:
                    AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
                    AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
                    AddMatrix(res, fillStyle.GradientMatrix);
                    AddGradientColors(res, fillStyle.Gradient.GradientRecords);
                    break;
            }
            return res;
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
            xml.Add(new XElement("Matrix", XMatrix.ToXml(matrix)));
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
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
