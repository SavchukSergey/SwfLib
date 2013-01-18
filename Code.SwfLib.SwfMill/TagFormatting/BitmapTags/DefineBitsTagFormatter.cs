using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsTagFormatter : TagFormatterBase<DefineBitsTag> {
        public override XElement FormatTag(DefineBitsTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(DefineBitsTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(DefineBitsTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
