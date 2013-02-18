using System.Xml.Linq;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleRGB {

        public static XElement ToXml(LineStyleRGB lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGB.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGB FromXml(XElement xLineStyle) {
            var xColor = xLineStyle.Element("color").Element("Color");
            return new LineStyleRGB {
                Width = xLineStyle.RequiredUShortAttribute("width"),
                Color = XColorRGB.FromXml(xColor)
            };
        }
    }
}
