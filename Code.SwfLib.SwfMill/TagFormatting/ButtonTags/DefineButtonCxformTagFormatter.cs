using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonCxformTagFormatter : TagFormatterBase<DefineButtonCxformTag> {
        protected override XElement FormatTagElement(DefineButtonCxformTag tag, XElement xTag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineButtonCxformTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineButtonCxformTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
