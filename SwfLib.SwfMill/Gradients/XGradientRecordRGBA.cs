using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;
using SwfLib.Gradients;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGBA {

        public static GradientRecordRGBA FromXml(XElement xRecord) {
            var record = new GradientRecordRGBA {
                Ratio = xRecord.RequiredByteAttribute("position"),
                Color = XColorRGBA.FromXml(xRecord.RequiredElement("color").Element("Color"))
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
