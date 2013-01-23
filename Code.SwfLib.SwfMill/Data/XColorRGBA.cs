using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XColorRGBA {

        public static XElement ToXml(SwfRGBA color) {
            return new XElement("Color",
                new XAttribute("red", color.Red),
                new XAttribute("green", color.Green),
                new XAttribute("blue", color.Blue),
                new XAttribute("alpha", color.Alpha));
        }
    }
}
