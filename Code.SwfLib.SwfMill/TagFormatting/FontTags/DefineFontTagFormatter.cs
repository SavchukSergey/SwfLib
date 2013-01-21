using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {
        public override XElement FormatTag(DefineFontTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(DefineFontTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(DefineFontTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
