using System.Xml.Linq;
using Code.SwfLib.Data;
using SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XColorRGB {

        public static SwfRGB FromXml(XElement xColor) {
            var color = new SwfRGB();
            var xRed = xColor.Attribute("red");
            var xGreen = xColor.Attribute("green");
            var xBlue = xColor.Attribute("blue");
            color.Red = xRed != null ? byte.Parse(xRed.Value) : (byte)0;
            color.Green = xGreen != null ? byte.Parse(xGreen.Value) : (byte)0;
            color.Blue = xBlue != null ? byte.Parse(xBlue.Value) : (byte)0;
            return color;
        }

        public static XElement ToXml(SwfRGB color) {
            return new XElement("Color",
                new XAttribute("red", color.Red),
                new XAttribute("green", color.Green),
                new XAttribute("blue", color.Blue));
        }
    }
}
