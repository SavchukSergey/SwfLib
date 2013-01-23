using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGBA {

        public static XElement ToXml(GradientRecordRGBA record) {
            return new XElement("GradientItem",
                new XAttribute("position", record.Ratio),
                new XElement("color", XColorRGBA.ToXml(record.Color))
            );
        }
    }
}
