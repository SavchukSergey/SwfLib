using System;
using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class ColorRGBFormatter : DataFormatterBase<SwfRGB> {
        public ColorRGBFormatter(DataFormatters formatters)
            : base(formatters) {
        }

        protected override void InitData(XElement element, out SwfRGB data) {
            throw new NotImplementedException();
        }

        protected override void AcceptElement(XElement element, ref SwfRGB data) {
            throw new NotImplementedException();
        }

        protected override void AcceptAttribute(XAttribute attrib, ref SwfRGB data) {
            throw new NotImplementedException();
        }

        public override XElement Format(ref SwfRGB data) {
            return new XElement(XName.Get("Color"),
                    new XAttribute(XName.Get("red"), data.Red),
                    new XAttribute(XName.Get("green"), data.Green),
                    new XAttribute(XName.Get("blue"), data.Blue));

        }
    }
}
