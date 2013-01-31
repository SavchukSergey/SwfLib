using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ProtectTagFormatter : TagFormatterBase<ProtectTag> {
        protected override void FormatTagElement(ProtectTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(ProtectTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(ProtectTag tag, XElement element) {
        }

        public override string TagName {
            get { return "Protect"; }
        }
    }
}
