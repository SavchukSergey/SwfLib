using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGBA {

        public static GradientRecordRGBA FromXml(XElement xRecord) {
            var xPosition = xRecord.Attribute("position");
            var xColor = xRecord.Element("color");
            var record = new GradientRecordRGBA {
                Ratio = byte.Parse(xPosition.Value),
                Color = XColorRGBA.FromXml(xColor.Element("Color"))
            };
            return record;
        }

        public static XElement ToXml(GradientRecordRGBA record) {
            return new XElement("GradientItem",
                new XAttribute("position", record.Ratio),
                new XElement("color", XColorRGBA.ToXml(record.Color))
            );
        }
    }
}
