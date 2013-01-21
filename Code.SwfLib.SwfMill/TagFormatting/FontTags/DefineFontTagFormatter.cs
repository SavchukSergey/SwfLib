using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {
        protected override XElement FormatTagElement(DefineFontTag tag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineFontTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineFontTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
