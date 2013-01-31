using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EndTagFormatter : TagFormatterBase<EndTag> {

        protected override void FormatTagElement(EndTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(EndTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(EndTag tag, XElement element) {
        }

        public override string TagName {
            get { return "End"; }
        }
    }
}