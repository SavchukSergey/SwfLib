using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XColorRGBA {

        public static SwfRGBA FromXml(XElement xColor) {
            var color = new SwfRGBA();
            var xRed = xColor.Attribute("red");
            var xGreen = xColor.Attribute("green");
            var xBlue = xColor.Attribute("blue");
            var xAlpha = xColor.Attribute("alpha");
            color.Red = xRed != null ? byte.Parse(xRed.Value) : (byte)0;
            color.Green = xGreen != null ? byte.Parse(xGreen.Value) : (byte)0;
            color.Blue = xBlue != null ? byte.Parse(xBlue.Value) : (byte)0;
            color.Alpha = xAlpha != null ? byte.Parse(xAlpha.Value) : (byte)0;
            return color;
        }

        public static XElement ToXml(SwfRGBA color) {
            return new XElement("Color",
                new XAttribute("red", color.Red),
                new XAttribute("green", color.Green),
                new XAttribute("blue", color.Blue),
                new XAttribute("alpha", color.Alpha));
        }
    }
}
