using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class RectangleDataFormatter : DataFormatterBase<SwfRect> {

        public RectangleDataFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out SwfRect data) {
            data.XMax = 0;
            data.YMax = 0;
            data.XMin = 0;
            data.YMin = 0;
        }

        protected override void AcceptElement(XElement element, ref SwfRect data) {
            switch (element.Name.LocalName) {
                default:
                    OnUnknownElementFound(element);
                    break;
            }
        }

        protected override void AcceptAttribute(XAttribute attrib, ref SwfRect data) {
            switch (attrib.Name.LocalName) {
                case "left":
                    data.XMin = int.Parse(attrib.Value);
                    break;
                case "top":
                    data.YMin = int.Parse(attrib.Value);
                    break;
                case "right":
                    data.XMax = int.Parse(attrib.Value);
                    break;
                case "bottom":
                    data.YMax = int.Parse(attrib.Value);
                    break;
                default:
                    OnUnknownAttributeFound(attrib);
                    break;
            }
        }

        public override XElement Format(ref SwfRect data) {
            return new XElement(XName.Get("Rectangle"),
                    new XAttribute(XName.Get("left"), data.XMin),
                    new XAttribute(XName.Get("right"), data.XMax),
                    new XAttribute(XName.Get("top"), data.YMin),
                    new XAttribute(XName.Get("bottom"), data.YMax));
        }
    }
}
