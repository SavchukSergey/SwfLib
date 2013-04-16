using System;
using System.Xml.Linq;
using SwfLib.Data;

namespace SwfLib.SwfMill.Data {
    public static class XRect {

        public static SwfRect FromXml(XElement xRect) {
            if (xRect.Name.LocalName != "Rectangle") throw new FormatException("Invalid rectangle");

            var xLeft = xRect.Attribute("left");
            var xRight = xRect.Attribute("right");
            var xTop = xRect.Attribute("top");
            var xBottom = xRect.Attribute("bottom");

            return new SwfRect {
                XMin = xLeft != null ? int.Parse(xLeft.Value) : 0,
                XMax = xRight != null ? int.Parse(xRight.Value) : 0,
                YMin = xTop != null ? int.Parse(xTop.Value) : 0,
                YMax = xBottom != null ? int.Parse(xBottom.Value) : 0,
            };
        }

        public static XElement ToXml(SwfRect rect) {
            return new XElement("Rectangle",
                    new XAttribute("left", rect.XMin),
                    new XAttribute("right", rect.XMax),
                    new XAttribute("top", rect.YMin),
                    new XAttribute("bottom", rect.YMax));
        }
    }
}
