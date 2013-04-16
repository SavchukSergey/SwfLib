using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class MetadataTagFormatter : TagFormatterBase<MetadataTag> {

        protected override void FormatTagElement(MetadataTag tag, XElement xTag) {
            xTag.Add(XElement.Parse(tag.Metadata));
        }

        protected override void InitTag(MetadataTag tag, XElement element) {
            base.InitTag(tag, element);
            var val = element.Value.Trim();
            if (!string.IsNullOrEmpty(val)) {
                tag.Metadata = val;
            }
        }

        //TODO:value can come as a text not an xml and though won't get here.

        protected override bool AcceptTagElement(MetadataTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "RDF":
                    tag.Metadata = element.ToString();
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "Metadata"; }
        }
    }
}