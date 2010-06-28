using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class MatrixFormatter : DataFormatterBase<SwfMatrix> {

        public MatrixFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out SwfMatrix data) {
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
            //TODO: skew
            switch (attrib.Name.LocalName) {
                case "scaleX":
                    data.ScaleX = double.Parse(attrib.Value);
                    break;
                case "scaleY":
                    data.ScaleY = double.Parse(attrib.Value);
                    break;
                case "transX":
                    data.TranslateX = int.Parse(attrib.Value);
                    break;
                case "transY":
                    data.TranslateY = int.Parse(attrib.Value);
                    break;
                default:
                    OnUnknownAttributeFound(attrib);
                    break;
            }
        }

        public override XElement Format(ref SwfMatrix data) {
            //TODO: skew
            return new XElement(XName.Get("Transform"),
                new XAttribute(XName.Get("scaleX"), data.ScaleX),
                new XAttribute(XName.Get("scaleY"), data.ScaleY),
                new XAttribute(XName.Get("transX"), data.TranslateX),
                new XAttribute(XName.Get("transY"), data.TranslateY)
                );
        }
    }
}
