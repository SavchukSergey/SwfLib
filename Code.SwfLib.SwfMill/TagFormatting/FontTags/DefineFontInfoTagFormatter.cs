using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontInfoTagFormatter : TagFormatterBase<DefineFontInfoTag> {

        private const string REST_ELEM = "rest";

        public override void AcceptAttribute(DefineFontInfoTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.FontId = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineFontInfoTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case REST_ELEM:
                    tag.RestData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFontInfoTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONT_INFO_TAG),
                              new XAttribute(XName.Get(OBJECT_ID_ATTRIB), tag.FontId),
                              new XElement(REST_ELEM, Convert.ToBase64String(tag.RestData)));
        }
    }
}
