using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {

        protected override void FormatTagElement(DefineFontTag tag, XElement xTag) {
            var xOffsets = new XElement("offsets");
            foreach (var offset in tag.OffsetTable) {
                var xOffset = new XElement("offset", new XAttribute("value", offset));
                xOffsets.Add(xOffset);
            }
            xTag.Add(xOffsets);
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

        public override string TagName {
            get { return "DefineFont"; }
        }

    }
}
