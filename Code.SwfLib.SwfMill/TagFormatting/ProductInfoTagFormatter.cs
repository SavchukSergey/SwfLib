using System;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class ProductInfoTagFormatter : TagFormatterBase<ProductInfoTag> {
        protected override XElement FormatTagElement(ProductInfoTag tag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(ProductInfoTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(ProductInfoTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
