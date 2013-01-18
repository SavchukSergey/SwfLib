using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ProtectTagFormatter : TagFormatterBase<ProtectTag> {
        public override XElement FormatTag(ProtectTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(ProtectTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(ProtectTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
