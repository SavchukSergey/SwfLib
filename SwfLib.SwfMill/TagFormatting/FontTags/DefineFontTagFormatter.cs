using System.Xml.Linq;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontTagFormatter : TagFormatterBase<DefineFontTag> {

        protected override void FormatTagElement(DefineFontTag tag, XElement xTag) {
            var xOffsets = new XElement("offsets");
            foreach (var offset in tag.OffsetTable) {
                var xOffset = new XElement("offset", new XAttribute("value", offset));
                xOffsets.Add(xOffset);
            }
            xTag.Add(xOffsets);
        }

        protected override bool AcceptTagElement(DefineFontTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "offsets":
                    foreach (var xOffset in element.Elements()) {
                        var xValue = xOffset.Attribute("value");
                        tag.OffsetTable.Add(ushort.Parse(xValue.Value));
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "DefineFont"; }
        }

    }
}
