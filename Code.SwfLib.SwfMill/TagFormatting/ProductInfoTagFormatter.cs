using System;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class ProductInfoTagFormatter : TagFormatterBase<ProductInfoTag> {
        public override XElement FormatTag(ProductInfoTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(ProductInfoTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(ProductInfoTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
