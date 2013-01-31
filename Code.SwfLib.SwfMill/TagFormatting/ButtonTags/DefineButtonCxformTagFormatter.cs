using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonCxformTagFormatter : DefineButtonBaseTagFormatter<DefineButtonCxformTag> {
        protected override void FormatTagElement(DefineButtonCxformTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(DefineButtonCxformTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DefineButtonCxformTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineButtonCxform"; }
        }
    }
}
