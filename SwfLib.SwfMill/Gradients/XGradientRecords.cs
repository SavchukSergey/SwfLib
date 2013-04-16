using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Gradients;
using SwfLib.Gradients;

namespace Code.SwfLib.SwfMill.Gradients {
    public static class XGradientRecords {

        public static void FromXml(XElement xRecords, IList<GradientRecordRGB> records) {
            foreach (var xRecord in xRecords.Elements("GradientItem")) {
                records.Add(XGradientRecordRGB.FromXml(xRecord));
            }
        }

        public static void FromXml(XElement xRecords, IList<GradientRecordRGBA> records) {
            foreach (var xRecord in xRecords.Elements("GradientItem")) {
                records.Add(XGradientRecordRGBA.FromXml(xRecord));
            }
        }

        public static XElement ToXml(IList<GradientRecordRGB> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGB.ToXml(record);
                xColors.Add(xRecord);
            }
            return xColors;
        }

        public static XElement ToXml(IList<GradientRecordRGBA> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGBA.ToXml(record);
                xColors.Add(xRecord);
            }
            return xColors;
        }

    }
}
