using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGB {

        public static GradientRecordRGB FromXml(XElement xRecord) {
            var xPosition = xRecord.Attribute("position");
            var xColor = xRecord.Element("color");
            var record = new GradientRecordRGB {
                Ratio = byte.Parse(xPosition.Value),
                Color = XColorRGB.FromXml(xColor.Element("Color"))
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
