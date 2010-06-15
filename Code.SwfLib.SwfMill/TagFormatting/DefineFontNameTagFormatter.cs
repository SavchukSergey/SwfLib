using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineFontNameTagFormatter : TagFormatterBase<DefineFontNameTag> {

        public override void AcceptAttribute(DefineFontNameTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineFontNameTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFontNameTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONE_NAME_TAG),
                               new XAttribute(XName.Get("objectID"), tag.FontNameId),
                               new XAttribute(XName.Get("name"), tag.DisplayName),
                               new XAttribute(XName.Get("copyright"), tag.Copyright));
        }
    }
}
