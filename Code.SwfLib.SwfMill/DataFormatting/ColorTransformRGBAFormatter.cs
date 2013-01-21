using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    //TODO: does it match swfmill?
    public class ColorTransformRGBAFormatter : DataFormatterBase<ColorTransformRGBA> {
        public ColorTransformRGBAFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out ColorTransformRGBA data) {
            data.RedMultTerm = null;
            data.GreenMultTerm = null;
            data.BlueMultTerm = null;
            data.AlphaMultTerm = null;

            data.RedAddTerm = null;
            data.GreenAddTerm = null;
            data.BlueAddTerm = null;
            data.AlphaAddTerm = null;
        }

        protected override void AcceptElement(XElement element, ref ColorTransformRGBA data) {
            switch (element.Name.LocalName) {
                default:
                    OnUnknownElementFound(element);
                    break;
            }
        }

        protected override void AcceptAttribute(XAttribute attrib, ref ColorTransformRGBA data) {
            switch (attrib.Name.LocalName) {
                case "redmult":
                    data.RedMultTerm = short.Parse(attrib.Value);
                    break;
                case "greenmult":
                    data.GreenMultTerm = short.Parse(attrib.Value);
                    break;
                case "bluemult":
                    data.BlueMultTerm = short.Parse(attrib.Value);
                    break;
                case "alphamult":
                    data.AlphaMultTerm = short.Parse(attrib.Value);
                    break;
                case "redadd":
                    data.RedAddTerm = short.Parse(attrib.Value);
                    break;
                case "greenadd":
                    data.GreenAddTerm = short.Parse(attrib.Value);
                    break;
                case "blueadd":
                    data.BlueAddTerm = short.Parse(attrib.Value);
                    break;
                case "alphaadd":
                    data.AlphaAddTerm = short.Parse(attrib.Value);
                    break;
                default:
                    OnUnknownAttributeFound(attrib);
                    break;
            }
        }

        public override XElement Format(ref ColorTransformRGBA data) {
            var res = new XElement(XName.Get("ColorTransform2"));
            if (data.RedMultTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("factorRed"), data.RedMultTerm.Value));
            }
            if (data.GreenMultTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("factorGreen"), data.GreenMultTerm.Value));
            }
            if (data.BlueMultTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("factorBlue"), data.BlueMultTerm.Value));
            }
            if (data.AlphaMultTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("factorAlpha"), data.AlphaMultTerm.Value));
            }

            if (data.RedAddTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("redadd"), data.RedAddTerm.Value));
            }
            if (data.GreenAddTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("greenadd"), data.GreenAddTerm.Value));
            }
            if (data.BlueAddTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("blueadd"), data.BlueAddTerm.Value));
            }
            if (data.AlphaAddTerm.HasValue) {
                res.Add(new XAttribute(XName.Get("alphaadd"), data.AlphaAddTerm.Value));
            }
            return res;
        }
    }
}
