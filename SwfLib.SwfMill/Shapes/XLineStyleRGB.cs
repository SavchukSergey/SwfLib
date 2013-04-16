using System.Xml.Linq;
using SwfLib.Shapes.LineStyles;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Shapes {
    public class XLineStyleRGB {

        public static XElement ToXml(LineStyleRGB lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGB.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGB FromXml(XElement xLineStyle) {
            var xColor = xLineStyle.RequiredElement("color").Element("Color");
            return new LineStyleRGB {
                Width = xLineStyle.RequiredUShortAttribute("width"),
                Color = XColorRGB.FromXml(xColor)
            };
        }
    }
}
