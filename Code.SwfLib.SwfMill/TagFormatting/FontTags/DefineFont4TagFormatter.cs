using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFont4TagFormatter : DefineFontBaseFormatter<DefineFont4Tag> {
        protected override void FormatTagElement(DefineFont4Tag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(DefineFont4Tag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DefineFont4Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineFont4"; }
        }
    }
}
