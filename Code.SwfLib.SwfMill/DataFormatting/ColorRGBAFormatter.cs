using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class ColorRGBAFormatter : DataFormatterBase<SwfRGBA> {
        public ColorRGBAFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out SwfRGBA data) {
            data.Red = 0;
            data.Green = 0;
            data.Blue = 0;
            data.Alpha = 0;
        }

        protected override void AcceptElement(XElement element, ref SwfRGBA data) {
            switch (element.Name.LocalName) {
                default:
                    OnUnknownElementFound(element);
                    break;
            }
        }

        protected override void AcceptAttribute(XAttribute attrib, ref SwfRGBA data) {
            switch (attrib.Name.LocalName) {
                case "red":
                    data.Red = byte.Parse(attrib.Value);
                    break;
                case "green":
                    data.Green = byte.Parse(attrib.Value);
                    break;
                case "blue":
                    data.Blue = byte.Parse(attrib.Value);
                    break;
                case "alpha":
                    data.Alpha = byte.Parse(attrib.Value);
                    break;
                default:
                    OnUnknownAttributeFound(attrib);
                    break;
            }
        }

        public override XElement Format(ref SwfRGBA data) {
            return new XElement(XName.Get("Color"),
                    new XAttribute(XName.Get("red"), data.Red),
                    new XAttribute(XName.Get("green"), data.Green),
                    new XAttribute(XName.Get("blue"), data.Blue),
                    new XAttribute(XName.Get("alpha"), data.Alpha)
            );

        }
    }
}
