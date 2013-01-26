using System.Xml.Linq;
using Code.SwfLib.Fonts;

namespace Code.SwfLib.SwfMill.Shapes {
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

    }
}
