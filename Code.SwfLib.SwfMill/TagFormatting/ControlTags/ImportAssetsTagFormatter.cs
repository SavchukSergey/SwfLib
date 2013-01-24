using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ImportAssetsTagFormatter : TagFormatterBase<ImportAssetsTag> {
        protected override XElement FormatTagElement(ImportAssetsTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(ImportAssetsTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(ImportAssetsTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
