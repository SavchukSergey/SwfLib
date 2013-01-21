using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ProtectTagFormatter : TagFormatterBase<ProtectTag> {
        protected override XElement FormatTagElement(ProtectTag tag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(ProtectTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(ProtectTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
