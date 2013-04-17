using System.Xml.Linq;
using SwfLib.Fonts;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Shapes {
    /// <summary>
    /// Represents GlyphShape xml formatter.
    /// </summary>
    public class XGlyphShape {

        public static XElement ToXml(Glyph glyph) {
            var xShape = new XElement("GlyphShape");
            var xEdges = new XElement("edges");

            foreach (var shapeRecord in glyph.Records) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }

            xShape.Add(xEdges);
            return xShape;
        }

        public static Glyph FromXml(XElement xGlyph, Glyph glyph) {
            var xEdges = xGlyph.RequiredElement("edges");
            foreach (var xShapeRecord in xEdges.Elements()) {
                glyph.Records.Add(XShapeRecord.RGBFromXml(xShapeRecord));
            }
            return glyph;
        }
    }
}
