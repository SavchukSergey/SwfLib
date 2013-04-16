using System.Xml.Linq;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
    public class ProductInfoTagFormatter : TagFormatterBase<ProductInfoTag> {
        protected override void FormatTagElement(ProductInfoTag tag, XElement xTag) {
            //TODO: format & parse
        }

        public override string TagName {
            get { return "ProductInfo"; }
        }
    }
}
