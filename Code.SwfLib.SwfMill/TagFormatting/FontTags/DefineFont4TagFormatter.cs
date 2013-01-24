using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFont4TagFormatter : DefineFontBaseFormatter<DefineFont4Tag> {
        protected override XElement FormatTagElement(DefineFont4Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineFont4Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineFont4Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        protected override string TagName {
            get { return "DefineFont4"; }
        }
    }
}
