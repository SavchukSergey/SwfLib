using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class ProductInfoTagFormatter : TagFormatterBase<ProductInfoTag> {
        protected override void FormatTagElement(ProductInfoTag tag, XElement xTag) {
            //TODO: format & parse
        }

        public override string TagName {
            get { return "ProductInfo"; }
        }
    }
}
