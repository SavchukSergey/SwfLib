using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using SwfLib.Gradients;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGB {

        public static GradientRecordRGB FromXml(XElement xRecord) {
            var record = new GradientRecordRGB {
                Ratio = xRecord.RequiredByteAttribute("position"),
                Color = XColorRGB.FromXml(xRecord.RequiredElement("color").Element("Color"))
            };
            return record;
        }

        public static XElement ToXml(GradientRecordRGB record) {
            return new XElement("GradientItem",
                new XAttribute("position", record.Ratio),
                new XElement("color", XColorRGB.ToXml(record.Color))
            );
        }
    }
}
