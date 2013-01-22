using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class MatrixFormatter : DataFormatterBase<SwfMatrix> {

        public MatrixFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out SwfMatrix data) {
            data.HasScale = false;
            data.HasRotate = false;
            data.ScaleX = 1.0;
            data.ScaleY = 1.0;
            data.RotateSkew0 = 0.0;
            data.RotateSkew1 = 0.0;
            data.TranslateX = 0;
            data.TranslateY = 0;
        }

        protected override void AcceptElement(XElement element, ref SwfMatrix data) {
            switch (element.Name.LocalName) {
                default:
                    OnUnknownElementFound(element);
                    break;
            }
        }

        protected override void AcceptAttribute(XAttribute attrib, ref SwfMatrix data) {
            switch (attrib.Name.LocalName) {
                case "scaleX":
                    data.ScaleX = double.Parse(attrib.Value);
                    data.HasScale = true;
                    break;
                case "scaleY":
                    data.ScaleY = double.Parse(attrib.Value);
                    data.HasScale = true;
                    break;
                case "transX":
                    data.TranslateX = int.Parse(attrib.Value);
                    break;
                case "transY":
                    data.TranslateY = int.Parse(attrib.Value);
                    break;
                case "skewX":
                    data.RotateSkew0 = double.Parse(attrib.Value);
                    data.HasRotate = true;
                    break;
                case "skewY":
                    data.RotateSkew1 = double.Parse(attrib.Value);
                    data.HasRotate = true;
                    break;
                default:
                    OnUnknownAttributeFound(attrib);
                    break;
            }
        }

        public override XElement Format(ref SwfMatrix data) {
            var res = new XElement(XName.Get("Transform"),
                new XAttribute(XName.Get("transX"), data.TranslateX),
                new XAttribute(XName.Get("transY"), data.TranslateY));
            if (data.HasScale) {
                res.Add(new XAttribute(XName.Get("scaleX"), data.ScaleX));
                res.Add(new XAttribute(XName.Get("scaleY"), data.ScaleY));
            }
            if (data.HasRotate) {
                res.Add(new XAttribute(XName.Get("skewX"), data.RotateSkew0));
                res.Add(new XAttribute(XName.Get("skewY"), data.RotateSkew1));
            }
            return res;
        }
    }
}
