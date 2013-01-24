using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {

        protected override XElement FormatTagElement(DefineFontTag tag, XElement xTag) {
            var res = new XElement(SwfTagNameMapping.DEFINE_FONT_TAG,
                 new XAttribute(OBJECT_ID_ATTRIB, tag.FontID));
            var xOffsets = new XElement("offsets");
            foreach (var offset in tag.OffsetTable) {
                var xOffset = new XElement("offset", new XAttribute("value", offset));
                xOffsets.Add(xOffset);
            }
            res.Add(xOffsets);
            return res;
        }

        protected override void AcceptTagAttribute(DefineFontTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.FontID = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineFontTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "offsets":
                    foreach (var xOffset in element.Elements()) {
                        var xValue = xOffset.Attribute("value");
                        tag.OffsetTable.Add(ushort.Parse(xValue.Value));
                    }
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }
    }
}
