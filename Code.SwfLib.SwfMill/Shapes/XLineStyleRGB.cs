using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleRGB {

        public static XElement ToXml(LineStyleRGB lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGB.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGB FromXml(XElement xLineStyle) {
            var xWidth = xLineStyle.Attribute("width");
            var xColor = xLineStyle.Element("color").Element("Color");
            return new LineStyleRGB {
                Width = ushort.Parse(xWidth.Value),
                Color = XColorRGB.FromXml(xColor)
            };
        }
    }
}
