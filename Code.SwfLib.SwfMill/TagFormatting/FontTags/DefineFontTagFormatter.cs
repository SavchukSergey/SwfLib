using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {

        protected override XElement FormatTagElement(DefineFontTag tag, XElement xTag) {
            var xOffsets = new XElement("offsets");
            foreach (var offset in tag.OffsetTable) {
                var xOffset = new XElement("offset", new XAttribute("value", offset));
                xOffsets.Add(xOffset);
            }
            xTag.Add(xOffsets);
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineFontTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
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

        protected override string TagName {
            get { return "DefineFont"; }
        }

        protected override ushort? GetObjectID(DefineFontTag tag) {
            return tag.FontID;
        }

        protected override void SetObjectID(DefineFontTag tag, ushort value) {
            tag.FontID = value;
        }
    }
}
