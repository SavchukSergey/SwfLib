using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.SwfMill.Utils;
using SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XGlyph {

        public static XElement ToXml(Glyph glyph) {
            var xGlyph = new XElement("Glyph");
            xGlyph.Add(new XAttribute("map", glyph.Code));
            xGlyph.Add(XGlyphShape.ToXml(glyph));
            return xGlyph;
        }

        public static Glyph FromXml(XElement xGlyph) {
            var res = new Glyph {
                Code = xGlyph.RequiredUShortAttribute("map"),
            };
            XGlyphShape.FromXml(xGlyph.Element("GlyphShape"), res);
            return res;
        }
    }
}
