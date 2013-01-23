using System.Xml.Linq;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Gradients {
    public class XGradientRecordRGB {

        public static XElement ToXml(GradientRecordRGB record) {
            return new XElement("GradientItem",
                new XAttribute("position", record.Ratio),
                new XElement("color", XColorRGB.ToXml(record.Color))
            );
        }
    }
}
