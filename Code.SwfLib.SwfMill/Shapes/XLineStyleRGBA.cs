using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleRGBA {

        public static XElement ToXml(LineStyleRGBA lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGBA.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGBA FromXml(XElement xLineStyle) {
            throw new NotImplementedException();
        }
    }
}
