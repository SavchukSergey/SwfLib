﻿using System.Xml.Linq;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleRGBA {

        public static XElement ToXml(LineStyleRGBA lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGBA.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGBA FromXml(XElement xLineStyle) {
            const string node = "lineStyle";
            var xColor = xLineStyle.Element("color").Element("Color");
            return new LineStyleRGBA {
                Width = xLineStyle.RequiredUShortAttribute("width", node),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
