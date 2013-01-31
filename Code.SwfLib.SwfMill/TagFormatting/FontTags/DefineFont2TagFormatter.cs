using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFont2TagFormatter : DefineFontBaseFormatter<DefineFont2Tag> {
        protected override void FormatTagElement(DefineFont2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(DefineFont2Tag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DefineFont2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineFont2"; }
        }

    }
}
